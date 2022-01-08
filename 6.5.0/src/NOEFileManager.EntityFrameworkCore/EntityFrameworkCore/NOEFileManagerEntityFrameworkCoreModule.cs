using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NOEFileManager.EntityFrameworkCore
{
    [DependsOn(
        typeof(NOEFileManagerCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class NOEFileManagerEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NOEFileManagerEntityFrameworkCoreModule).GetAssembly());
        }
    }
}