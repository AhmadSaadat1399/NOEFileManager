using Microsoft.AspNetCore.Mvc;

namespace NOEFileManager.Web.Controllers
{
    public class HomeController : NOEFileManagerControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}