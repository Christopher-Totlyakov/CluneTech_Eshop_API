using Contracts.Repository;
using Contracts.Services;
using Entities;
using Models.Accounts;
using Models.Products;
using Models.Sales;
using System;
using System.Collections.Generic;
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
            var sale = await _saleRepository.GetWithDetailsByIdAsync(id);
            return sale is null ? null : Map(sale);
        }

        public async Task<SaleResponseDto> CreateAsync(SaleDto saleDto)
        {

            Client? client = await _clientRepository.GetByIdAsync(saleDto.ClientId);
            Product? product = await _productRepository.GetByIdAsync(saleDto.ProductId);
            if (client == null || product == null)
                throw new ArgumentException("Invalid client or product ID");

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
            var sale = await _saleRepository.GetWithDetailsByIdAsync(id);
            if (sale == null) return false;

            sale.Quantity = saleDto.Quantity;
            sale.OrderDate = DateTime.UtcNow;

            await _saleRepository.UpdateAsync(sale);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) return false;
            await _saleRepository.DeleteAsync(sale);
            return true;
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
