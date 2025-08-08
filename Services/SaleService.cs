using Contracts.Repository;
using Contracts.Services;
using Entities;
using Models.Accounts;
using Models.Products;
using Models.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;

        public SaleService(
            ISaleRepository saleRepository,
            IProductRepository productRepository,
            IClientRepository clientRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _clientRepository = clientRepository;
        }

        public async Task<List<SaleResponseDto>> GetAllAsync()
        {
            var sales = await _saleRepository.GetAllWithDetailsAsync();
            return sales.Select(Map).ToList();
        }

        public async Task<SaleResponseDto?> GetByIdAsync(long id)
        {
            if (id <= 0)
                throw new ValidationException("Invalid sale ID.");

            var sale = await _saleRepository.GetWithDetailsByIdAsync(id);
            return sale is null ? null : Map(sale);
        }

        public async Task<SaleResponseDto> CreateAsync(SaleDto saleDto)
        {
            ValidateSaleDto(saleDto);

            var client = await _clientRepository.GetByIdAsync(saleDto.ClientId)
                ?? throw new KeyNotFoundException($"Client with ID {saleDto.ClientId} not found.");

            var product = await _productRepository.GetByIdAsync(saleDto.ProductId)
                ?? throw new KeyNotFoundException($"Product with ID {saleDto.ProductId} not found.");

            if (product.Price <= 0)
                throw new ValidationException("Product price must be greater than zero.");

            var sale = new Sale
            {
                Client = client,
                Product = product,
                Quantity = saleDto.Quantity,
                OrderDate = DateTime.UtcNow
            };

            await _saleRepository.CreateAsync(sale);

            return Map(sale);
        }

        public async Task<bool> UpdateAsync(long id, SaleDto saleDto)
        {
            if (id <= 0)
                throw new ValidationException("Invalid sale ID.");

            ValidateSaleDto(saleDto);

            var sale = await _saleRepository.GetWithDetailsByIdAsync(id);
            if (sale == null) return false;

            var client = await _clientRepository.GetByIdAsync(saleDto.ClientId)
                ?? throw new KeyNotFoundException($"Client with ID {saleDto.ClientId} not found.");

            var product = await _productRepository.GetByIdAsync(saleDto.ProductId)
                ?? throw new KeyNotFoundException($"Product with ID {saleDto.ProductId} not found.");

            if (product.Price <= 0)
                throw new ValidationException("Product price must be greater than zero.");

            sale.Client = client;
            sale.Product = product;
            sale.Quantity = saleDto.Quantity;
            sale.OrderDate = DateTime.UtcNow;

            await _saleRepository.UpdateAsync(sale);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            if (id <= 0)
                throw new ValidationException("Invalid sale ID.");

            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) return false;

            await _saleRepository.DeleteAsync(sale);
            return true;
        }

        private void ValidateSaleDto(SaleDto dto)
        {
            if (dto == null)
                throw new ValidationException("Sale data is required.");

            if (dto.ClientId <= 0)
                throw new ValidationException("Invalid client ID.");

            if (dto.ProductId <= 0)
                throw new ValidationException("Invalid product ID.");

            if (dto.Quantity <= 0)
                throw new ValidationException("Quantity must be greater than zero.");
        }

        private SaleResponseDto Map(Sale s) => new SaleResponseDto
        {
            Id = s.Id,
            Quantity = s.Quantity,
            OrderDate = s.OrderDate,
            Client = new ClientDto
            {
                Id = s.Client.Id,
                FirstName = s.Client.FirstName,
                LastName = s.Client.LastName,
                Age = s.Client.Age,
                Sex = s.Client.Sex
            },
            Product = new ProductSalesDto
            {
                Id = s.Product.Id,
                Name = s.Product.Name,
                Price = s.Product.Price
            }
        };
    }
}
