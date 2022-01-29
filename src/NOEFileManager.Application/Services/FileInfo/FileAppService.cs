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
using Microsoft.AspNetCore.Cors;


namespace NOEFileManager.Application.Services.FileInfo

{
    [EnableCors("_defaultCorsPolicyName")]
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IRepository<FileStorage, Guid> _fileRepository;
        public FileAppService(IRepository<FileStorage, Guid> fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public List<FileStorage> SaveFileByLists(List<IFormFile> UploadFile)
        {
            List<FileStorage> MyList = new List<FileStorage>();
            foreach (var item in UploadFile)
            {

                if (item.Length > 0)
                {
                    if (item.Length > 0)
                    {
                        var filename = System.IO.Path.GetFileName(item.FileName);
                        var fileExtention = System.IO.Path.GetExtension(filename);
                        var FileSize = item.Length;
                        var objFiles = new FileStorage()
                        {
                            FileCreatedUtc = DateTime.UtcNow,
                            //FilePath = System.IO.Path.GetFullPath(UploadFile.FileName, fileExtention),
                            FileHidden = true,
                            FileName = filename,
                            FileExtension = fileExtention,
                            FileContentType = item.ContentType,
                            FileType = Core.Domain.Entities.Enums.FileType.File,
                            // FileAllowAnanymousAccess = UploadFile.FileAllowAnanymousAccess,  
                            // FileSize = new System.IO.FileInfo(int= UploadFile.FileSize),
                            FileSize = item.Length,
                            FileDescription = "UploadFile",
                            ReferenceId = Guid.NewGuid()
                        };
                        using (var target = new System.IO.MemoryStream())
                        {
                            item.CopyTo(target);

                            objFiles.FileHash = target.ToArray();
                        }
                        _fileRepository.Insert(objFiles);
                        MyList.Add(objFiles);

                    }
                }

            }
            return MyList;
        }
        public void SaveFileList(List<IFormFile> UploadFile)
        {

            // List<IFormFile> RangeList = new List<IFormFile>();
            foreach (var item in UploadFile)
            {
                if (item.Length > 0)
                {
                    var filename = System.IO.Path.GetFileName(item.FileName);
                    var fileExtention = System.IO.Path.GetExtension(filename);
                    var FileSize = item.Length;
                    var objFiles = new FileStorage()
                    {
                        FileCreatedUtc = DateTime.UtcNow,
                        //FilePath = System.IO.Path.GetFullPath(UploadFile.FileName, fileExtention),
                        FileHidden = true,
                        FileName = filename,
                        FileExtension = fileExtention,
                        FileContentType = item.ContentType,
                        FileType = Core.Domain.Entities.Enums.FileType.File,
                        // FileAllowAnanymousAccess = UploadFile.FileAllowAnanymousAccess,  
                        // FileSize = new System.IO.FileInfo(int= UploadFile.FileSize),
                        FileSize = item.Length,
                        FileDescription = "UploadFile",
                        ReferenceId = Guid.NewGuid()
                    };
                    using (var target = new System.IO.MemoryStream())
                    {
                        item.CopyTo(target);

                        objFiles.FileHash = target.ToArray();
                    }
                    _fileRepository.Insert(objFiles);

                }

            }
        }

        // public async Task<IActionResult> ListUploadFile(ICollection<IFormFile> FileList)
        // {
        //     foreach (var item in FileList)
        //     {
        //         if (item.Length > 0)
        //         {
        //             var filename = System.IO.Path.GetFileName(item.FileName);
        //             var fileExtention = System.IO.Path.GetExtension(filename);
        //             var FileSize = item.Length;
        //             var objFiles = new FileStorage()
        //             {
        //                 FileCreatedUtc = DateTime.UtcNow,
        //                 //FilePath = System.IO.Path.GetFullPath(UploadFile.FileName, fileExtention),
        //                 FileHidden = true,
        //                 FileName = filename,
        //                 FileExtension = fileExtention,
        //                 FileContentType = item.ContentType,
        //                 FileType = Core.Domain.Entities.Enums.FileType.File,
        //                 // FileAllowAnanymousAccess = UploadFile.FileAllowAnanymousAccess,  
        //                 // FileSize = new System.IO.FileInfo(int= UploadFile.FileSize),
        //                 FileSize = item.Length,
        //                 FileDescription = "UploadFile"
        //             };
        //             using (var target = new System.IO.MemoryStream())
        //             {
        //                 item.CopyTo(target);

        //                 objFiles.FileHash = target.ToArray();
        //             }
        //             _fileRepository.Insert(objFiles);

        //         }
        //     }


        // }
        public void SaveFile(IFormFile UploadFile)
        {


            if (UploadFile.Length > 0)
            {
                var filename = System.IO.Path.GetFileName(UploadFile.FileName);
                var fileExtention = System.IO.Path.GetExtension(filename);
                var FileSize = UploadFile.Length;
                var objFiles = new FileStorage()
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
                    FileSize = UploadFile.Length,
                    FileDescription = "UploadFile"
                };
                using (var target = new System.IO.MemoryStream())
                {
                    UploadFile.CopyTo(target);

                    objFiles.FileHash = target.ToArray();
                }
                _fileRepository.Insert(objFiles);

            }
            else
            {
                throw new Exception("Null");
            }

        }

        public FileStorage DownloadFile(string FileName)
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

                throw new Exception("File in Database NotFound");
            }
        }


        public FileStorage GetById(Guid id)

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

        //get list Generic class by:Ahmad Saadat
    }

}