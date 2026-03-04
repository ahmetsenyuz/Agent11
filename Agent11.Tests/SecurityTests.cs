using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agent11.Controllers;

namespace Agent11.Tests
{
    [TestClass]
    public class SecurityTests
    {
        [TestMethod]
        public void Security_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Security();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Security_ViewNameIsCorrect()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Security() as ViewResult;

            // Assert
            Assert.AreEqual("Security", result.ViewName);
        }
    }
}