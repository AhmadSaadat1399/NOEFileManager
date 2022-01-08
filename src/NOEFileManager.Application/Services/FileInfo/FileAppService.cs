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
    public class FileAppService : ApplicationService, IFileAppService
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
                        FileHidden = true,
                        FileName = filename,
                        FileExtension = fileExtention,
                        FileContentType = UploadFile.ContentType,
                        FileType = Core.Domain.Entities.Enums.FileType.File,
                        // FileAllowAnanymousAccess = UploadFile.FileAllowAnanymousAccess,  
                        // FileSize = new System.IO.FileInfo(int= UploadFile.FileSize),
                        FileSize = UploadFile.Length / 2048,
                        FileDescription = "UploadFile"
                    };
                    using (var target = new System.IO.MemoryStream())
                    {
                        UploadFile.CopyTo(target);
                        
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
                byte[] ConvertFileToByte = GetFile.FileHash;
                var ConvertByteToStream = new MemoryStream(GetFile.FileHash);
                return GetFile;
            }
            catch (System.Exception)
            {

                throw new Exception("فایل مورد نظر شما در بانک اطلاعاتی یافت نشد");
            }
        }

        public SaveFiles GetById(Guid id)

        {
            var FindById = _fileRepository.FirstOrDefault(it => it.Id == id);
            if (FindById == null)
            {
                throw new Exception("Oops 404");
            }
            byte[] ConvertFileToByte = FindById.FileHash;
            var ConvertByteToStream = new MemoryStream(FindById.FileHash);
            return FindById;

        }

        public List<Guid> GetList(Guid id)
        {
            var GetList = _fileRepository.GetAllList(it => it.Id == id);

            throw new NotImplementedException();
        }


    }
}