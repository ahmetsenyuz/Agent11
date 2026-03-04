using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agent11.Controllers;

namespace Agent11.Tests
{
    [TestClass]
    public class FormSubmissionTests
    {
        [TestMethod]
        public void FormSubmission_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.FormSubmission();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void FormSubmission_ViewNameIsCorrect()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.FormSubmission() as ViewResult;

            // Assert
            Assert.AreEqual("FormSubmission", result.ViewName);
        }
    }
}