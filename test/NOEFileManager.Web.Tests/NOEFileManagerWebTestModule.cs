using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NOEFileManager.Web.Startup;
namespace NOEFileManager.Web.Tests
{
    [DependsOn(
        typeof(NOEFileManagerWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class NOEFileManagerWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NOEFileManagerWebTestModule).GetAssembly());
        }
    }
}