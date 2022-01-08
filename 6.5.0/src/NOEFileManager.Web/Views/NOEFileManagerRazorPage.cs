using Abp.AspNetCore.Mvc.Views;

namespace NOEFileManager.Web.Views
{
    public abstract class NOEFileManagerRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected NOEFileManagerRazorPage()
        {
            LocalizationSourceName = NOEFileManagerConsts.LocalizationSourceName;
        }
    }
}
