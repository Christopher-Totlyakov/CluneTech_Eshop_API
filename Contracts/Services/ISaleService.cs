using Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    /// <summary>
    /// Defines the contract for sale-related operations, including retrieval, creation, updating, and deletion of sales.
    /// </summary>
    public interface ISaleService
    {
        /// <summary>
        /// Retrieves all sales asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a list of sales.</returns>
        Task<List<SaleResponseDto>> GetAllAsync();

        /// <summary>
        /// Retrieves a sale by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the sale.</param>
        /// <returns>A task representing the asynchronous operation, containing the sale if found, or null otherwise.</returns>
        Task<SaleResponseDto?> GetByIdAsync(long id);

        /// <summary>
        /// Creates a new sale asynchronously.
        /// </summary>
        /// <param name="saleDto">The data transfer object containing the sale information.</param>
        /// <returns>A task representing the asynchronous operation, containing the created sale.</returns>
        Task<SaleResponseDto> CreateAsync(SaleDto saleDto);

        /// <summary>
        /// Updates an existing sale asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the sale to update.</param>
        /// <param name="saleDto">The data transfer object containing the updated sale information.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the update was successful, otherwise false.</returns>
        Task<bool> UpdateAsync(long id, SaleDto saleDto);

        /// <summary>
        /// Deletes a sale by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteAsync(long id);
    }
}
