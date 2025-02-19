﻿using System;
using System.Collections.Generic;
using Senparc.Ncf.Core.Extensions;
using Senparc.Ncf.Core.Models;
using Senparc.Ncf.Log;
using System.IO;
using Senparc.Ncf.Core.Utility;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Senparc.Ncf.Core.Cache
{
    public interface IBaseDictionaryCache<TKey, TValue> : IBaseDictionaryCache<TKey, TValue, TValue>
        where TValue : class, new()
    {
    }

    public interface IBaseDictionaryCache<TKey, TValue, TEntity> : IBaseCache<TValue>
           where TValue : class, new()
    {
        #region 同步方法

        TValue InsertObjectToCache(TKey key);
        TValue InsertObjectToCache(TKey key, TEntity obj);
        TValue GetObject(TKey key);
        void RemoveObject(TKey key);
        bool UpdateToCache(TKey key, TValue obj);

        #endregion

        #region 异步方法

        Task<TValue> InsertObjectToCacheAsync(TKey key);
        Task<TValue> InsertObjectToCacheAsync(TKey key, TEntity obj);
        Task<TValue> GetObjectAsync(TKey key);
        Task RemoveObjectAsync(TKey key);
        Task<bool> UpdateToCacheAsync(TKey key, TValue obj);

        #endregion
    }


    public abstract class BaseDictionaryCache<TKey, TValue> : BaseDictionaryCache<TKey, TValue, TValue>,
        IBaseDictionaryCache<TKey, TValue>
        where TValue : class, new()
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CACHE_KEY"></param>
        /// <param name="db"></param>
        /// <param name="timeOut">单位：分钟。1440为一天。</param>
        public BaseDictionaryCache(string CACHE_KEY, INcfDbData db, int timeOut)
            : base(CACHE_KEY, db, timeOut)
        {
            base.TimeOut = timeOut;
        }
    }

    public abstract class BaseDictionaryCache<TKey, TValue, TEntity> :
        BaseCache<TValue>, IBaseDictionaryCache<TKey, TValue, TEntity>
        where TValue : class, new()
        where TEntity : class/*, new()*/
    {
        /// <summary>
        /// 获取缓存中最终的Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetFinalCacheKey(TKey key)
        {
            //TODO:判断Key类型
            TypeCode code = key == null ? TypeCode.DBNull : Type.GetTypeCode(key.GetType());
            string keyCode = null;
            switch (code)
            {
                case TypeCode.DBNull: throw new Exception("Key不允许为空！");
                case TypeCode.String:
                case TypeCode.Boolean:
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.Double:
                case TypeCode.Single:
                    keyCode = key.ToString();
                    break;
                default:
                    code = TypeCode.Object;
                    string keyStr = System.Text.Json.JsonSerializer.Serialize(key);
                    keyCode = MD5.GetMD5Code(keyStr, "");//将对象序列化，然后拼接成字符串并转成MD5，确保唯一性。性能上可能会有一些损失，所以尽量不要太复杂的类型做Key
                    break;
            }

            string finalKey = null;

            if (base.Cache is Senparc.CO2NET.Cache.CsRedis.BaseRedisObjectCacheStrategy)
            {
                finalKey = $"{keyCode}";
            }
            else
            {
                finalKey = $"{CacheKey}@@@{keyCode}";//有的缓存策略可能不允许:作为分隔符[LocalCache 存在问题]
            }

            return finalKey;
        }

        //protected virtual ArraySegment<byte> SerializeObject(object value)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        //.NET 8.0 中已标记为过时且无法编译
        //        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(ms, value);

        //        return new ArraySegment<byte>(ms.GetBuffer(), 0, (int)ms.Length);
        //    }
        //}

        ///// <summary>
        ///// 获取指定Key下所有的子Key的Value
        ///// </summary>
        ///// <param name="key">xxx*</param>
        ///// <returns></returns>
        //protected virtual IList<TValue> GetObjectList(TKey key)
        //{
        //    if (key == null)
        //    {
        //        return null;
        //    }
        //    var finalCacheKey = GetFinalCacheKey(key);
        //    var allData =  base.Cache.GetAll();

        //    if (allData.ContainsKey(finalCacheKey))
        //    {
        //        return allData[finalCacheKey]
        //    }
        //    return 
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CACHE_KEY"></param>
        /// <param name="db"></param>
        /// <param name="timeOut">单位：分钟。1440为一天。</param>
        public BaseDictionaryCache(string CACHE_KEY, INcfDbData db, int timeOut)
            : base(CACHE_KEY, db)
        {
            base.TimeOut = timeOut;

            //强制初始化
            //var load = base.Data;
            //var finalCacheKey = GetFinalCacheKey(key);
            //if (base.Cache.CheckExisted(finalCacheKey))
            //{

            //}
        }
        #region 同步方法

        public override TValue Update()
        {
            return base.Update();
        }

        public abstract TValue InsertObjectToCache(TKey key);

        public virtual TValue InsertObjectToCache(TKey key, TEntity obj)
        {
            if (obj == null)
            {
                return null;
            }

            TValue fullObj = new TValue();
            var finalCacheKey = GetFinalCacheKey(key);
            if (fullObj is IBaseFullEntity<TEntity>)
            {
                try
                {
                    (fullObj as BaseFullEntity<TEntity>).CreateEntity(obj);

                    //if (base.Data == null)
                    //{
                    //    throw new Exception("base.Data=null");
                    //}
                    base.Cache.Set(finalCacheKey, fullObj);
                    return fullObj;
                }
                catch (Exception ex)
                {
                    //var msg = "系统调试记录cache的一个bug。发生错误：{0}。当前参数：base.Data：{1}（Count：{4}），key:{2}，obj：{3}。Null情况分别是：{4}，{5},{6}"
                    //    .With(ex.Message, base.Data, key, obj, base.Data == null, key == null, obj == null, base.Data.Count);

                    var msg = $"系统调试记录cache的一个bug。发生错误：{ex.Message}。再次访问base.Data=null：{base.Data == null}";//实际上这里base.Data还是为null
                    LogUtility.SystemLogger.Debug(msg, ex);
                    throw new Exception(msg, ex);
                }
            }
            else if (obj as TValue != null)
            {
                base.Cache.Set(finalCacheKey, obj as TValue);
                return obj as TValue;
            }

            base.Cache.Set(finalCacheKey, fullObj);
            return fullObj;
        }

        public virtual TValue GetObject(TKey key)
        {
            if (key == null)
            {
                return null;
            }

            var finalCacheKey = GetFinalCacheKey(key);

            if (base.Cache.CheckExisted(finalCacheKey))
            {
                return base.Cache.Get<TValue>(finalCacheKey);
            }
            else
            {
                return InsertObjectToCache(key);
            }
        }

        public virtual void RemoveObject(TKey key)
        {
            var finalCacheKey = GetFinalCacheKey(key);

            if (base.Cache.CheckExisted(finalCacheKey))
            {
                base.Cache.RemoveFromCache(finalCacheKey);
            }
        }

        public virtual bool UpdateToCache(TKey key, TValue obj)
        {
            var finalKey = GetFinalCacheKey(key);
            return base.UpdateToCache(finalKey, obj);
        }


        public override void RemoveCache()
        {
            throw new Exception("不可以使用此方法");
        }

        #endregion


        #region 异步方法

        public override async Task<TValue> UpdateAsync()
        {
            return await base.UpdateAsync().ConfigureAwait(false);
        }

        public abstract Task<TValue> InsertObjectToCacheAsync(TKey key);

        public virtual async Task<TValue> InsertObjectToCacheAsync(TKey key, TEntity obj)
        {
            if (obj == null)
            {
                return null;
            }

            TValue fullObj = new TValue();
            var finalCacheKey = GetFinalCacheKey(key);
            if (fullObj is IBaseFullEntity<TEntity>)
            {
                try
                {
                    (fullObj as BaseFullEntity<TEntity>).CreateEntity(obj);

                    //if (base.Data == null)
                    //{
                    //    throw new Exception("base.Data=null");
                    //}
                    await base.Cache.SetAsync(finalCacheKey, fullObj).ConfigureAwait(false);
                    return fullObj;
                }
                catch (Exception ex)
                {
                    //var msg = "系统调试记录cache的一个bug。发生错误：{0}。当前参数：base.Data：{1}（Count：{4}），key:{2}，obj：{3}。Null情况分别是：{4}，{5},{6}"
                    //    .With(ex.Message, base.Data, key, obj, base.Data == null, key == null, obj == null, base.Data.Count);

                    var msg = $"系统调试记录cache的一个bug。发生错误：{ex.Message}。再次访问base.Data=null：{base.Data == null}";//实际上这里base.Data还是为null
                    LogUtility.SystemLogger.Debug(msg, ex);
                    throw new Exception(msg, ex);
                }
            }
            else if (obj as TValue != null)
            {
                await base.Cache.SetAsync(finalCacheKey, obj as TValue).ConfigureAwait(false);
                return obj as TValue;
            }

            await base.Cache.SetAsync(finalCacheKey, fullObj).ConfigureAwait(false);
            return fullObj;
        }

        public virtual async Task<TValue> GetObjectAsync(TKey key)
        {
            if (key == null)
            {
                return null;
            }

            var finalCacheKey = GetFinalCacheKey(key);

            if (base.Cache.CheckExisted(finalCacheKey))
            {
                return await base.Cache.GetAsync<TValue>(finalCacheKey).ConfigureAwait(false);
            }
            else
            {
                return await InsertObjectToCacheAsync(key).ConfigureAwait(false);
            }
        }

        public virtual async Task RemoveObjectAsync(TKey key)
        {
            var finalCacheKey = GetFinalCacheKey(key);

            if (await base.Cache.CheckExistedAsync(finalCacheKey).ConfigureAwait(false))
            {
                await base.Cache.RemoveFromCacheAsync(finalCacheKey).ConfigureAwait(false);
            }
        }

        public virtual async Task<bool> UpdateToCacheAsync(TKey key, TValue obj)
        {
            var finalKey = GetFinalCacheKey(key);
            return await base.UpdateToCacheAsync(finalKey, obj).ConfigureAwait(false);
        }


        public override Task RemoveCacheAsync()
        {
            throw new Exception("不可以使用此方法");
        }

        #endregion
    }
}
