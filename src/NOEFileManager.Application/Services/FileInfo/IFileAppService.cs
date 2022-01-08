using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using NOEFileManager.Core;
using NOEFileManager.Core.Domain.Entities.FileInfo;
namespace NOEFileManager.Application.Services.FileInfo
{
    public interface IFileAppService : IApplicationService
    {

        void SaveFile(IFormFile input);
        SaveFiles DownloadFile(string FileName);
        SaveFiles GetById(Guid id);
        List<Guid> GetList(Guid id);

    }
}