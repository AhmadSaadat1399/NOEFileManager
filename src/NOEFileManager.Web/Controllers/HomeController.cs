using System;
using Microsoft.AspNetCore.Mvc;
using NOEFileManager.Application.Services.FileInfo;


namespace NOEFileManager.Web.Controllers
{
    public class HomeController : NOEFileManagerControllerBase
    {
        private readonly IFileAppService _FileAppService;
        public HomeController(IFileAppService FileAppService)
        {
            _FileAppService = FileAppService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDownloadFile()
        {
            var accessFile = _FileAppService.DownloadFile("Masoudi-DeyBalal.mp3");
            return File(accessFile.FileHash, "application/octet-stream", accessFile.FileName);

        }
        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            var accessFileId = _FileAppService.GetById(id);
            return File(accessFileId.FileHash, "application/octet-stream", accessFileId.FileName);
        }


    }
}