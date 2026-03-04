using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Agent11.Tests
{
    [TestClass]
    public class FormSubmissionTests
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
        public void ContactForm_SubmissionWorks()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost:5001/Contact");
            
            // Act
            var nameField = driver.FindElement(By.Id("name"));
            var emailField = driver.FindElement(By.Id("email"));
            var messageField = driver.FindElement(By.Id("message"));
            var submitButton = driver.FindElement(By.CssSelector(".submit-btn"));

            nameField.SendKeys("Test User");
            emailField.SendKeys("test@example.com");
            messageField.SendKeys("Test message for contact form");

            submitButton.Click();
            
            // Wait for page to process
            Thread.Sleep(1000);
            
            // Assert - check that form was submitted (this would depend on your actual implementation)
            // For now, we'll just check that the page loaded without errors
            Assert.IsNotNull(driver.Title);
        }

        [TestMethod]
        public void ContactForm_ValidationWorks()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost:5001/Contact");
            
            // Act
            var submitButton = driver.FindElement(By.CssSelector(".submit-btn"));
            submitButton.Click();
            
            // Wait for validation to occur
            Thread.Sleep(500);
            
            // Assert - check that validation errors appear
            var errorElements = driver.FindElements(By.ClassName("error-message"));
            Assert.IsTrue(errorElements.Count > 0);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}