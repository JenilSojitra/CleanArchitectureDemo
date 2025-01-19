
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.UnitTests.Domain
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithValidData_ShouldSucceed()
        {
            // Arrange
            string name = "Test Product";
            string description = "Test Description";
            decimal price = 19.99m;

            // Act
            var product = new Product(name, description, price);

            // Assert
            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(price, product.Price);
        }

        [Theory]
        [InlineData("", "Description", 19.99)]
        [InlineData("Name", "Description", 0)]
        [InlineData("Name", "Description", -1)]
        public void CreateProduct_WithInvalidData_ShouldThrowException(string name, string description, decimal price)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(name, description, price));
        }
    }
}
