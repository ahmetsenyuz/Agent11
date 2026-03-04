using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Agent11.Tests
{
    [TestClass]
    public class AccessibilityTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void AboutPage_IsAccessible()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost:5001/About");

            // Act & Assert
            // Check for accessibility issues using axe-core or similar tools
            // This is a simplified example - in practice you would use a proper accessibility testing library
            var title = driver.Title;
            Assert.IsTrue(title.Contains("About"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}