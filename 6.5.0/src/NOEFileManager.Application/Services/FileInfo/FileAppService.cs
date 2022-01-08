using System;
using Microsoft.Net.Http.Headers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using NOEFileManager.Core.Domain.Entities.FileInfo;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;


namespace NOEFileManager.Application.Services.FileInfo

{
    public class FileAppService : ApplicationService
    {
        private readonly IRepository<SaveFiles, Guid> _fileRepository;
        public FileAppService(IRepository<SaveFiles, Guid> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public void SaveFile(IFormFile UploadFile)
        {
            if (UploadFile != null)
            {
                if (UploadFile.Length > 0)
                {
                    var filename = System.IO.Path.GetFileName(UploadFile.FileName);
                    var fileExtention = System.IO.Path.GetExtension(filename);

                    var objFiles = new SaveFiles()
                    {
                        FileCreatedUtc = DateTime.UtcNow,
                        //FilePath = System.IO.Path.GetFullPath(UploadFile.FileName, fileExtention),
                        // FileHidden = UploadFile.,
                        FileName = filename,
                        FileExtension = fileExtention,
                        FileContentType = UploadFile.ContentType,
                        FileType = Core.Domain.Entities.Enums.FileType.File,
                        // FileAllowAnanymousAccess = UploadFile.FileAllowAnanymousAccess,  
                        // FileSize = new System.IO.FileInfo(int= UploadFile.FileSize),
                        //  FileSize = UploadFile.
                        FileDescription = "UploadFile"
                    };
                    using (var target = new System.IO.MemoryStream())
                    {
                        UploadFile.CopyTo(target);
                        //objFiles.FileSize = objFiles.FileHash.Length;
                        objFiles.FileHash = target.ToArray();
                    }
                    _fileRepository.Insert(objFiles);

                }
            }
        }

        public SaveFiles DownloadFile(string FileName)
        {
            try
            {

                var GetFile = _fileRepository.FirstOrDefault(it => it.FileName == FileName);
                if (GetFile == null)
                    throw new Exception("Not Found...");
                // byte[] SelectedFile = GetFile.FileHash;
                // var dataStream = new System.IO.MemoryStream(GetFile.FileHash);
                // return File(dataStream, "application/octet-stream", GetFile.FileName);

                // return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                // {
                //     FileDownloadName = excelName
                // };
                return GetFile;
            }
            catch (System.Exception)
            {

                throw new Exception("");
            }
        }

    }
}