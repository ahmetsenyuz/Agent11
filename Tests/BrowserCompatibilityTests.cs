using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Threading;

namespace Agent11.Tests
{
    [TestClass]
    public class BrowserCompatibilityTests
    {
        private IWebDriver driver;

        [TestMethod]
        public void AboutPage_LoadsInChrome()
        {
            // Arrange
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            
            // Act
            driver.Navigate().GoToUrl("https://localhost:5001/About");
            Thread.Sleep(1000);
            
            // Assert
            Assert.IsTrue(driver.Title.Contains("About"));
            
            driver.Quit();
        }

        [TestMethod]
        public void AboutPage_LoadsInFirefox()
        {
            // Arrange
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            driver = new FirefoxDriver(options);
            
            // Act
            driver.Navigate().GoToUrl("https://localhost:5001/About");
            Thread.Sleep(1000);
            
            // Assert
            Assert.IsTrue(driver.Title.Contains("About"));
            
            driver.Quit();
        }

        [TestMethod]
        public void AboutPage_LoadsInSafari()
        {
            // Arrange
            var options = new SafariOptions();
            // Note: Safari options are limited in headless mode
            driver = new SafariDriver(options);
            
            // Act
            driver.Navigate().GoToUrl("https://localhost:5001/About");
            Thread.Sleep(1000);
            
            // Assert
            Assert.IsTrue(driver.Title.Contains("About"));
            
            driver.Quit();
        }
    }
}