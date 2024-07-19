using System.Collections.Specialized;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Senparc.Ncf.UnitTestExtension;
using Senparc.Ncf.UnitTestExtension.Entities;
using Senparc.Xncf.DynamicData;
using Senparc.Xncf.DynamicData.Domain.Services;

namespace Senparc.Xncf.DynamicDataTests
{
    [TestClass]
    public class BaseDynamicDataTest : BaseNcfUnitTest
    {
        public static Action<DataList> InitSeedData = dataList =>
        {
            // TableMetadata
            List<TableMetadata> tableMetadataList = new() {
                 new("User","用户表"),
                 new("Product","产品表"),
                 new("Order","订单表"),
            };

            for (int i = 1; i <= tableMetadataList.Count; i++)
            {
                var data = tableMetadataList[i - 1];
                data.Id = i;
            }

            dataList.Add(tableMetadataList);

            Func<string, int> GetTableId = name => dataList.GetList<TableMetadata>().First(z => z.TableName == name).Id;

            // ColumnMetadata
            List<ColumnMetadata> columnMetadataList = new() {
                 new ColumnMetadata(GetTableId("User"),"Guid","Text",false,""),
                 new ColumnMetadata(GetTableId("User"),"UserName","Text",false,""),
                 new ColumnMetadata(GetTableId("User"),"Balance","Float",false,"0.0"),

                 new ColumnMetadata(GetTableId("Product"),"Guid", "Text", false, ""),
                 new ColumnMetadata(GetTableId("Product"),"Name", "Text", false, ""),
                 new ColumnMetadata(GetTableId("Product"),"Price", "Float", false, "0.0"),

                 new ColumnMetadata(GetTableId("Order"),"Guid", "Text", false, ""),
                 new ColumnMetadata(GetTableId("Order"),"UserGuid", "Text", false, ""),
                 new ColumnMetadata(GetTableId("Order"),"ProductGuid", "Text", false, ""),
                 new ColumnMetadata(GetTableId("Order"),"Price", "Float", false, "0.0"),
                 new ColumnMetadata(GetTableId("Order"),"State", "Enums(Open,Paid,Closed)", false, "0.0"),
            };

            for (int i = 1; i <= columnMetadataList.Count; i++)
            {
                var item = columnMetadataList[i - 1];
                item.Id = i;

                item.TableMetadata = dataList.GetList<TableMetadata>().First(z => z.Id == item.TableMetadataId);
            }

            dataList.Add(columnMetadataList);

            foreach (var item in dataList.GetList<TableMetadata>())
            {
                item.ColumnMetadatas = dataList.GetList<ColumnMetadata>().Where(z => z.TableMetadataId == item.Id).ToList();
            }

        };

        //protected TableDataService _tableDataService;
        protected TableMetadataService _tableMetadataService;

        public BaseDynamicDataTest(Action<IServiceCollection> servicesRegister = null, Action<DataList> initSeedData = null)
            : base(servicesRegister, initSeedData ?? InitSeedData)
        {
            //var tableMetadataRepo = base.GetRespositoryObject<TableMetadata>();
            //_tableMetadataService = new TableMetadataService(tableMetadataRepo, base._serviceProvider);
        }

        protected override void BeforeRegisterServiceCollection(IServiceCollection services)
        {
            base.BeforeRegisterServiceCollection(services);

            Console.WriteLine("BaseDynamicDataTest.BeforeRegisterServiceCollection");

            services.AddScoped<TableMetadataService>();
        }

        protected override void RegisterServiceCollectionFinished(IServiceCollection services)
        {
            base.RegisterServiceCollectionFinished(services);
        }
    }
}