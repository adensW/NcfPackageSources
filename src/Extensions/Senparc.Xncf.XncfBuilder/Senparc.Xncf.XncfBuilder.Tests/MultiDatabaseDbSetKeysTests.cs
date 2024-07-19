using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Senparc.CO2NET.Extensions;
using Senparc.Ncf.Core.Models;
using Senparc.Ncf.Core.Tests;
using Senparc.Ncf.XncfBase;
using System;
using System.Linq;

namespace Senparc.Xncf.XncfBuilder.Tests
{
    [TestClass]
    public class MultiDatabaseDbSetKeysTests : TestBase
    {
        IServiceCollection _services;
        protected override void RegisterServiceCollectionFinished(IServiceCollection services)
        {
            base.RegisterServiceCollectionFinished(services);

            _services = services;
        }

        public MultiDatabaseDbSetKeysTests()
        {
            Console.WriteLine(typeof(Senparc.Xncf.XncfBuilder.Register).FullName);
            Senparc.Ncf.Core.Register.TryRegisterMiniCore(services => { }, app => { });

            var env = _services.BuildServiceProvider().GetService<IHostEnvironment>();
            var result = Senparc.Ncf.XncfBase.Register.StartNcfEngine(_services, base.Configuration, env, null);
            //Senparc.Ncf.XncfBase.Register.UseXncfModules()
        }

        [TestMethod]
        public void RunTest()
        {
            Console.WriteLine("XncfRegisterManager.RegisterList: " + XncfRegisterManager.RegisterList.Count);
            Assert.IsTrue(Senparc.Ncf.XncfBase.XncfRegisterManager.RegisterList.Count > 0);
            Console.WriteLine(XncfRegisterManager.RegisterList.Count);
            Assert.IsTrue(XncfRegisterManager.RegisterList.Count > 0);

            var allEntitySetInfo = EntitySetKeys.GetAllEntitySetInfo();
            Console.WriteLine(allEntitySetInfo.Count);
            Assert.IsTrue(allEntitySetInfo.Count > 0);

            Console.WriteLine(allEntitySetInfo.ToJson(true));
            Console.WriteLine("\r\n SenparcEntityTypes:");
            Console.WriteLine(allEntitySetInfo.First().Value.SenparcEntityTypes.Select(z => z.Name).ToJson(true));
        }
    }
}
