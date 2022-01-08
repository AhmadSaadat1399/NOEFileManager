using Abp.AspNetCore.Mvc.Controllers;

namespace NOEFileManager.Web.Controllers
{
    public abstract class NOEFileManagerControllerBase: AbpController
    {
        protected NOEFileManagerControllerBase()
        {
            LocalizationSourceName = NOEFileManagerConsts.LocalizationSourceName;
        }
    }
}