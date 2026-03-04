using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agent11.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public IntegrationTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task AboutPage_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/About");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task AboutPage_ContainsExpectedContent()
        {
            // Act
            var response = await _client.GetAsync("/About");
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.IsTrue(responseContent.Contains("About Page"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}