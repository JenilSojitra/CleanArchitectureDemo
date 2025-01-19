
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.UnitTests.Infrastructure
{
    public class ProductRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public ProductRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldAddProductToDatabase()
        {
            // Arrange
            using var context = new ApplicationDbContext(_dbContextOptions);
            var repository = new ProductRepository(context);
            var product = new Product("Test Product", "Description", 19.99m);

            // Act
            var result = await repository.AddAsync(product);

            // Assert
            Assert.NotEqual(0, result.Id);
            var savedProduct = await context.Products.FindAsync(result.Id);
            Assert.NotNull(savedProduct);
            Assert.Equal(product.Name, savedProduct.Name);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            // Arrange
            using var context = new ApplicationDbContext(_dbContextOptions);
            var repository = new ProductRepository(context);

            await context.Products.AddRangeAsync(
                new Product("Test 1", "Description 1", 19.99m),
                new Product("Test 2", "Description 2", 29.99m)
            );
            await context.SaveChangesAsync();

            // Act
            var results = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, results.Count());
        }
    }
}
