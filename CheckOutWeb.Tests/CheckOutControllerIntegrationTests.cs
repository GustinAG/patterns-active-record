using ActiveRecord.BusinessLogic;
using ActiveRecord.CheckOutWeb.Controllers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActiveRecord.CheckOutWeb.Tests
{
    [TestClass]
    public class CheckOutControllerIntegrationTests
    {
        [TestMethod]
        public void Index_ShouldReturnZeroTotalFirst()
        {
            // Arrange
            var controller = new CheckOutController(new CheckOutServices());

            // Act
            var result = controller.Index();

            // Assert
            var checkOut = result.ShouldHaveModel<Models.CheckOut>();
            checkOut.TotalPrice.Should().Be(0);
        }

        [TestMethod]
        public void Index_ShouldReturnPositiveTotal_WhenSomethingScanned()
        {
            // Arrange
            var controller = new CheckOutController(new CheckOutServices());
            controller.Index(new Models.CheckOut(null) { ScannedCode = 5 });

            // Act
            var result = controller.Index();

            // Assert
            var checkOut = result.ShouldHaveModel<Models.CheckOut>();
            checkOut.TotalPrice.Should().BePositive();
        }
    }
}
