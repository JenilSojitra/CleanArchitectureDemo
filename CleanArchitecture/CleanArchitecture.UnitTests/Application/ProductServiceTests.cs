
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Moq;

namespace CleanArchitecture.UnitTests.Application
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingProduct_ShouldReturnProduct()
        {
            // Arrange
            var product = new Product("Test", "Description", 19.99m);
            _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(product);

            // Act
            var result = await _productService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Price, result.Price);
        }

        [Fact]
        public async Task CreateAsync_ValidProduct_ShouldSucceed()
        {
            // Arrange
            var createDto = new CreateProductDto("Test", "Description", 19.99m);
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                .ReturnsAsync((Product p) => p);

            // Act
            var result = await _productService.CreateAsync(createDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createDto.Name, result.Name);
            Assert.Equal(createDto.Price, result.Price);
        }
    }
}
