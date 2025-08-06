using Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    /// <summary>
    /// Service interface for handling account-related operations.
    /// </summary>
    public interface IAccountService
    {


        /// <summary>
        /// Retrieves all accounts asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of account data.</returns>
        Task<List<AccountResponseDto>> GetAllAsync();

      
    }
}
