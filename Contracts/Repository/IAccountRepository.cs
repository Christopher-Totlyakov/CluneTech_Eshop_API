using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Interface for account repository.
/// </summary>
public interface IAccountRepository : IRepositoryBase<Account>
{
    /// <summary>
    /// Retrieves all accounts along with their associated client data asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of accounts with clients.</returns>
    Task<List<Account>> GetAllWithClientAsync();

    /// <summary>
    /// Retrieves a specific account by ID along with its associated client data asynchronously.
    /// </summary>
    /// <param name="id">The ID of the account to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the account with client data if found; otherwise, null.</returns>
    Task<Account?> GetWithClientByIdAsync(long id);
    
    /// <summary>
    /// Retrieves a specific account by username with associated client data asynchronously.
    /// </summary>
    /// <param name="username">The username of the account to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the account with client data if found; otherwise, null.</returns>

    Task<Account?> GetWithClientByUsernameAsync(string username);
}

