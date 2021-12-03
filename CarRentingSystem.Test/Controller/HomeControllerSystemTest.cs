namespace CarRentingSystem.Test.Controller
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;
    public class HomeControllerSystemTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public HomeControllerSystemTest(WebApplicationFactory<Startup> factory) 
            => this.factory = factory;

        [Fact]
        public async Task IndexShouldReturnCorrectStatusCode()
        {
            //Arrange
            var client = this.factory.CreateClient();

            //Act
            var result = await client.GetAsync("/");

            //Assert
            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
