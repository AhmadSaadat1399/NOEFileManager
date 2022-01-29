using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NOEFileManager.Core.Domain.Entities.FileInfo;
namespace NOEFileManager.EntityFrameworkCore
{
    public class NOEFileManagerDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<FileStorage> saveFiles { get; set; }
        public NOEFileManagerDbContext(DbContextOptions<NOEFileManagerDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileCreatedUtc);
            modelBuilder.Entity<FileStorage>().Property(it => it.FilePath).HasMaxLength(100);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileHidden);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileName).HasMaxLength(100);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileExtension).HasMaxLength(25);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileContentType);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileType);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileAllowAnanymousAccess);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileSize);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileHash);
            modelBuilder.Entity<FileStorage>().Property(it => it.FileDescription).HasMaxLength(150);
            modelBuilder.Entity<FileStorage>().Property(it => it.ReferenceId);
            modelBuilder.Entity<FileStorage>().ToTable("FileStorages");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);
            dbContextOptionsBuilder.UseNpgsql();
        }
    }
}
