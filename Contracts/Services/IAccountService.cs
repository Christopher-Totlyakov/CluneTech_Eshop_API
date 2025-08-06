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
        /// Retrieves an account by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the account to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the account data.</returns>
        Task<AccountResponseDto> GetByIdAsync(long id);

        /// <summary>
        /// Retrieves all accounts asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of account data.</returns>
        Task<List<AccountResponseDto>> GetAllAsync();

        /// <summary>
        /// Creates a new account with client data asynchronously.
        /// </summary>
        /// <param name="accountClientDto">The account and client data transfer object.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created account data.</returns>
        Task<AccountResponseDto> CreateAsync(AccountWithClientDto accountClientDto);

        /// <summary>
        /// Updates an existing account with new data asynchronously.
        /// </summary>
        /// <param name="id">The ID of the account to update.</param>
        /// <param name="accountClientDto">The updated account and client data transfer object.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the update was successful, otherwise false.</returns>
        Task<bool> UpdateAsync(long id, AccountWithClientDto accountClientDto);

        /// <summary>
        /// Deletes an account by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the account to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteAsync(long id);

        /// <summary>
        /// Authenticates an account using login credentials asynchronously.
        /// </summary>
        /// <param name="loginDto">The login data transfer object containing username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the authenticated account data.</returns>
        Task<AccountResponseDto> LoginAsync(LoginDto loginDto);
    }
}
