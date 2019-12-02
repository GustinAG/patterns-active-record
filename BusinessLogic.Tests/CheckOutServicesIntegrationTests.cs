using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActiveRecord.BusinessLogic.Tests
{
    [TestClass]
    public class CheckOutServicesIntegrationTests
    {
        [TestMethod]
        public void CurrentBill_ShouldReturnZeroBill_WhenNothingScanned()
        {
            // Arrange
            var services = new CheckOutServices();
            services.Start();

            // Act
            var bill = services.CurrentBill;

            // Assert
            bill.Should().NotBeNull();
            bill.TotalPrice.Should().Be(0);
        }

        [TestMethod]
        public void CurrentBill_ShouldReturnPositiveBill_WhenSomethingScanned()
        {
            // Arrange
            var services = new CheckOutServices();
            services.Start();
            services.Scan(12345678);

            // Act
            var bill = services.CurrentBill;

            // Assert
            bill.Should().NotBeNull();
            bill.TotalPrice.Should().BePositive();
        }

        [TestMethod]
        public void CurrentBill_ShouldReturnSingleProductBill_WhenSameScannedTwice()
        {
            // Arrange
            const long Code = 123456;
            var services = new CheckOutServices();
            services.Start();

            services.Scan(Code);
            services.Scan(Code);

            // Act
            var bill = services.CurrentBill;

            // Assert
            bill.Should().NotBeNull();
            bill.TotalPrice.Should().BePositive();
            bill.Products.Should().HaveCount(1);
        }

        [TestMethod]
        public void BreakBuild()
        {
            // Test what happens if I break the build - with a failed unit test?
            true.Should().BeFalse("Just to test breaking the CI build...");
        }
    }
}
