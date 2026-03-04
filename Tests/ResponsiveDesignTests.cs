using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace Agent11.Tests
{
    [TestClass]
    public class ResponsiveDesignTests
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
        public void AboutPage_ResizesCorrectly()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost:5001/About");
            
            // Act
            var window = driver.Manage().Window;
            
            // Test different screen sizes
            var sizes = new[]
            {
                new Size(320, 480),   // Mobile
                new Size(768, 1024),  // Tablet
                new Size(1024, 768),  // Laptop
                new Size(1920, 1080)  // Desktop
            };

            foreach (var size in sizes)
            {
                window.Size = size;
                Thread.Sleep(500); // Allow page to adjust
                
                // Assert that page elements are still visible and properly laid out
                var aboutSection = driver.FindElement(By.ClassName("about-page"));
                Assert.IsNotNull(aboutSection);
                
                // Additional assertions could check element positions, sizes, etc.
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}