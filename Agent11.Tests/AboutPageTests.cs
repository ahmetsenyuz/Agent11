using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agent11.Controllers;

namespace Agent11.Tests
{
    [TestClass]
    public class AboutPageTests
    {
        [TestMethod]
        public void AboutPage_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.About();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void AboutPage_ViewNameIsCorrect()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About", result.ViewName);
        }
    }
}