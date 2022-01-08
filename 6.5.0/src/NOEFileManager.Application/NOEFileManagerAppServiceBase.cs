using Abp.Application.Services;

namespace NOEFileManager
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class NOEFileManagerAppServiceBase : ApplicationService
    {
        protected NOEFileManagerAppServiceBase()
        {
            LocalizationSourceName = NOEFileManagerConsts.LocalizationSourceName;
        }
    }
}