using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    /// <summary>
    /// Defines the contract for the Sale repository, providing methods for retrieving sales with related details.
    /// </summary>
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
        /// <summary>
        /// Retrieves all sales with their related details asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a list of sales with details.</returns>
        Task<List<Sale>> GetAllWithDetailsAsync();

        /// <summary>
        /// Retrieves a specific sale by identifier with related details asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the sale.</param>
        /// <returns>A task representing the asynchronous operation, containing the sale with details, or null if not found.</returns>
        Task<Sale?> GetWithDetailsByIdAsync(long id);
    }
}
