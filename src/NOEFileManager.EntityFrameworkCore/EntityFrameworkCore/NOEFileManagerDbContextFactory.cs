using NOEFileManager.Configuration;
using NOEFileManager.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NOEFileManager.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class NOEFileManagerDbContextFactory : IDesignTimeDbContextFactory<NOEFileManagerDbContext>
    {
        public NOEFileManagerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NOEFileManagerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(builder,configuration.GetConnectionString(NOEFileManagerConsts.ConnectionStringName));

            return new NOEFileManagerDbContext(builder.Options);
        }
    }
}