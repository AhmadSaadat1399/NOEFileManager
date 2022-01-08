using Abp.Modules;
using Abp.Reflection.Extensions;
using NOEFileManager.Localization;

namespace NOEFileManager
{
    public class NOEFileManagerCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            NOEFileManagerLocalizationConfigurer.Configure(Configuration.Localization);
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = NOEFileManagerConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NOEFileManagerCoreModule).GetAssembly());
        }
    }
}