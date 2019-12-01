using ActiveRecord.CheckOutWeb.Controllers;
using ActiveRecord.CheckOutWeb.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActiveRecord.CheckOutWeb.Tests
{
    [TestClass]
    public class HomeControllerUnitTests
    {
        [TestMethod]
        public void Index_ShouldReturnSomeAppName()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            var info = result.ShouldHaveModel<AppInfo>();
            info?.Name.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void About_ShouldReturnSomeCopyrightText()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About();

            // Assert
            var info = result.ShouldHaveModel<AppInfo>();
            info?.Copyright.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void Contact_ShouldReturnSomeSupportEmail()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact();

            // Assert
            var info = result.ShouldHaveModel<ContactInfo>();
            info?.SupportEmail.Should().NotBeNullOrWhiteSpace();
        }
    }
}
