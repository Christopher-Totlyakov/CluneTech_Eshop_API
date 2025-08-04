using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    /// <summary>
    /// Defines the contract for product-related business operations.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of all products.</returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the product if found; otherwise, null.</returns>
        Task<Product?> GetByIdAsync(long id);

        /// <summary>
        /// Asynchronously creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(Product product);

        /// <summary>
        /// Asynchronously updates an existing product.
        /// </summary>
        /// <param name="product">The product with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Asynchronously deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(long id);
    }
}
