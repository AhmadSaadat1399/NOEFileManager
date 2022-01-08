using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NOEFileManager
{
    [DependsOn(
        typeof(NOEFileManagerCoreModule),   
        typeof(AbpAutoMapperModule))]
    public class NOEFileManagerApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NOEFileManagerApplicationModule).GetAssembly());
        }
    }
}