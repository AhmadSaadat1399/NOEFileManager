using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NOEFileManager.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NOEFileManagerDbContext> builder, string connectionString)
        {
            /* This is the single point to configure DbContextOptions for NOEFileManagerDbContext */
            // dbContextOptions.UseSqlServer(connectionString);
            builder.UseLazyLoadingProxies().UseNpgsql(connectionString);

        }
        public static void Configure(DbContextOptionsBuilder<NOEFileManagerDbContext> builder, DbConnection connection)
        {
            builder.UseLazyLoadingProxies().UseNpgsql(connection);
        }
    }
}
