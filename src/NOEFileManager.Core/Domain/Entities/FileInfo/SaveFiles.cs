using System;
using System.IO;
using Abp.Domain.Entities;
using NOEFileManager.Core.Domain.Entities.Enums;
namespace NOEFileManager.Core.Domain.Entities.FileInfo
{
    public class SaveFiles : Entity<Guid>
    {
        public SaveFiles() { }
        public virtual DateTime FileCreatedUtc { get; set; }
        public virtual string FilePath { get; set; }
        public virtual bool FileHidden { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FileExtension { get; set; }
        public virtual string FileContentType { get; set; }
        public virtual FileType FileType { get; set; }
        public virtual bool FileAllowAnanymousAccess { get; set; }
        public virtual long FileSize { get; set; }
        public virtual Byte[] FileHash { get; set; }
        public virtual string FileDescription { get; set; }

    }
}