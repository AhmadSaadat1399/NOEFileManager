using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NOEFileManager.Core.Domain.Entities.FileInfo;
namespace NOEFileManager.EntityFrameworkCore
{
    public class NOEFileManagerDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<SaveFiles> saveFiles { get; set; }
        public NOEFileManagerDbContext(DbContextOptions<NOEFileManagerDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileCreatedUtc);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FilePath).HasMaxLength(100);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileHidden);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileName).HasMaxLength(100);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileExtension).HasMaxLength(25);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileContentType);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileType);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileAllowAnanymousAccess);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileSize);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileHash);
            modelBuilder.Entity<SaveFiles>().Property(it => it.FileDescription).HasMaxLength(150);
            modelBuilder.Entity<SaveFiles>().ToTable("SaveFile");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);
            dbContextOptionsBuilder.UseNpgsql();
        }
    }
}
