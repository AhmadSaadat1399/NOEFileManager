using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NOEFileManager.Configuration;
using NOEFileManager.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace NOEFileManager.Web.Startup
{
    [DependsOn(
        typeof(NOEFileManagerApplicationModule), 
        typeof(NOEFileManagerEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class NOEFileManagerWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public NOEFileManagerWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(NOEFileManagerConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<NOEFileManagerNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(NOEFileManagerApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NOEFileManagerWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(NOEFileManagerWebModule).Assembly);
        }
    }
}
