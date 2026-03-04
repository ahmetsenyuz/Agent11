using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agent11.Controllers;

namespace Agent11.Tests
{
    [TestClass]
    public class ResponsiveDesignTests
    {
        [TestMethod]
        public void ResponsiveDesign_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.ResponsiveDesign();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ResponsiveDesign_ViewNameIsCorrect()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.ResponsiveDesign() as ViewResult;

            // Assert
            Assert.AreEqual("ResponsiveDesign", result.ViewName);
        }
    }
}