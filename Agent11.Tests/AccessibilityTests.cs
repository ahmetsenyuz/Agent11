using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agent11.Controllers;

namespace Agent11.Tests
{
    [TestClass]
    public class AccessibilityTests
    {
        [TestMethod]
        public void Accessibility_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Accessibility();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Accessibility_ViewNameIsCorrect()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Accessibility() as ViewResult;

            // Assert
            Assert.AreEqual("Accessibility", result.ViewName);
        }
    }
}