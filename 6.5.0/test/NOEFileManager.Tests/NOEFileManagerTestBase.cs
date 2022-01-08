using System;
using System.Threading.Tasks;
using Abp.TestBase;
using NOEFileManager.EntityFrameworkCore;
using NOEFileManager.Tests.TestDatas;

namespace NOEFileManager.Tests
{
    public class NOEFileManagerTestBase : AbpIntegratedTestBase<NOEFileManagerTestModule>
    {
        public NOEFileManagerTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<NOEFileManagerDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<NOEFileManagerDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<NOEFileManagerDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<NOEFileManagerDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<NOEFileManagerDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<NOEFileManagerDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<NOEFileManagerDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<NOEFileManagerDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
