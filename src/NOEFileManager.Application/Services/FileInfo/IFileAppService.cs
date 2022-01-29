using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOEFileManager.Core;
using NOEFileManager.Core.Domain.Entities.FileInfo;
namespace NOEFileManager.Application.Services.FileInfo
{
    public interface IFileAppService : IApplicationService
    {

        void SaveFile(IFormFile input);
        FileStorage DownloadFile(string FileName);
        FileStorage GetById(Guid id);
        List<Guid> GetList(Guid id);
        //  Task<IActionResult> ListUploadFile(ICollection<IFormFile> FileList);

    }
}