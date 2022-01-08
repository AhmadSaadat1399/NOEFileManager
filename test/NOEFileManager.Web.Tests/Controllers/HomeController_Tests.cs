using System.Threading.Tasks;
using NOEFileManager.Web.Controllers;
using Shouldly;
using Xunit;

namespace NOEFileManager.Web.Tests.Controllers
{
    public class HomeController_Tests: NOEFileManagerWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
