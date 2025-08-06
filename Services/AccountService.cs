using Contracts.Repository;
using Contracts.Services;
using Entities;
using Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<AccountResponseDto>> GetAllAsync()
    {
        var accounts = await _accountRepository.GetAllWithClientAsync();
        return accounts.Select(MapToResponseDto).ToList();
    }


    private static AccountResponseDto MapToResponseDto(Account account)
    {
        return new AccountResponseDto
        {
            Id = account.Id,
            Username = account.Username,
            Client = account.Client == null ? null : new ClientDto
            {
                Id = account.Client.Id,
                FirstName = account.Client.FirstName,
                LastName = account.Client.LastName,
                Age = account.Client.Age,
                Sex = account.Client.Sex
            }
        };
    }
}