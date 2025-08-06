using Contracts.Repository.ProductManagement;
using Contracts.Services;
using Entities;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<Product?> GetByIdAsync(long id) =>
            await _productRepository.GetByIdAsync(id);

        public async Task<Product> CreateAsync(ProductDto productDto) 
        {
            var product = new Product
            {
                Name = productDto.Name,
                Type = productDto.Type,
                Price = productDto.Price
            };

            await _productRepository.CreateAsync(product);
            return product;
        }

        public async Task<bool> UpdateAsync(long id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = productDto.Name;
            existingProduct.Type = productDto.Type;
            existingProduct.Price = productDto.Price;


            await _productRepository.UpdateAsync(existingProduct);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(product);
            return true;
        }
    }
}
