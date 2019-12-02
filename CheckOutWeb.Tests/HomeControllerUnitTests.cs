using System.Web.Mvc;
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
            ViewResult result;
            using (var controller = new HomeController())
            {
                // Act
                result = controller.Index();
            }

            // Assert
            var info = result.ShouldHaveModel<AppInfo>();
            info?.Name.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void About_ShouldReturnSomeCopyrightText()
        {
            // Arrange
            ViewResult result;
            using (var controller = new HomeController())
            {
                // Act
                result = controller.About();
            }

            // Assert
            var info = result.ShouldHaveModel<AppInfo>();
            info?.Copyright.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void Contact_ShouldReturnSomeSupportEmail()
        {
            // Arrange
            ViewResult result;
            using (var controller = new HomeController())
            {
                // Act
                result = controller.Contact();
            }

            // Assert
            var info = result.ShouldHaveModel<ContactInfo>();
            info?.SupportEmail.Should().NotBeNullOrWhiteSpace();
        }
    }
}
