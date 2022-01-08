using System;
using Abp.Application.Services.Dto;
using NOEFileManager.Core.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace NOEFileManager.Application.Services.FileInfo
{
    public class FileDto : EntityDto<Guid>
    {
        public FileDto() { }
        public DateTime FileCreatedUtc { get; set; }
        public string FilePath { get; set; }
        public bool FileHidden { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileContentType { get; set; }
        public FileType FileType { get; set; }
        public bool FileAllowAnanymousAccess { get; set; }
        public long FileSize { get; set; }
        public Byte[] FileHash { get; set; }
        public string FileDescription { get; set; }

    }
}