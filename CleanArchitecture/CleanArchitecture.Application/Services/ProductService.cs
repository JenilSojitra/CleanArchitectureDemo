
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return new ProductDto(product.Id, product.Name, product.Description, product.Price);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price));
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product(dto.Name, dto.Description, dto.Price);
            var created = await _productRepository.AddAsync(product);
            return new ProductDto(created.Id, created.Name, created.Description, created.Price);
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            product.UpdateDetails(dto.Name, dto.Description, dto.Price);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
