using ActiveRecord.CheckOut.Contracts;
using ActiveRecord.CheckOutWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ActiveRecord.CheckOutWeb.Tests
{
    [TestClass]
    public class CheckOutControllerUnitTests
    {
        [TestMethod]
        public void Index_ShouldResumeBill()
        {
            // Arrange
            var service = Substitute.For<ICheckOutService>();
            var controller = new CheckOutController(service);

            // Act
            controller.Index(new Models.CheckOut(null));

            // Assert
            service.Received().Resume(Arg.Any<int>());
        }
    }
}
