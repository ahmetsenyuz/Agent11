using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agent11.Controllers;

namespace Agent11.Tests
{
    [TestClass]
    public class BrowserCompatibilityTests
    {
        [TestMethod]
        public void BrowserCompatibility_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.BrowserCompatibility();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void BrowserCompatibility_ViewNameIsCorrect()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.BrowserCompatibility() as ViewResult;

            // Assert
            Assert.AreEqual("BrowserCompatibility", result.ViewName);
        }
    }
}