using NOEFileManager.EntityFrameworkCore;

namespace NOEFileManager.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly NOEFileManagerDbContext _context;

        public TestDataBuilder(NOEFileManagerDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}