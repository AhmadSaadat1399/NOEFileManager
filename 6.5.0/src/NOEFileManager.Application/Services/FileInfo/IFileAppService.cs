using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using NOEFileManager.Core;
using NOEFileManager.Core.Domain.Entities.FileInfo;
namespace NOEFileManager.Application.Services.FileInfo
{
    public interface IFileAppService : IApplicationService
    {

        void SaveFile(FileDto input);
        
    }
}