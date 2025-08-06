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

    public async Task<AccountResponseDto> GetByIdAsync(long id)
    {
        var account = await _accountRepository.GetWithClientByIdAsync(id);
        return account is null ? null : MapToResponseDto(account);
    }

    public async Task<List<AccountResponseDto>> GetAllAsync()
    {
        var accounts = await _accountRepository.GetAllWithClientAsync();
        return accounts.Select(MapToResponseDto).ToList();
    }

    public async Task<AccountResponseDto> CreateAsync(AccountWithClientDto accountClientdto)
    {
        var account = new Account
        {
            Username = accountClientdto.Username,
            PasswordHash = accountClientdto.PasswordHash,
            Client = new Client
            {
                FirstName = accountClientdto.FirstName,
                LastName = accountClientdto.LastName,
                Age = accountClientdto.Age,
                Sex = accountClientdto.Sex
            }
        };

        await _accountRepository.CreateAsync(account);
        return MapToResponseDto(account);
    }

    public async Task<bool> UpdateAsync(long id, AccountWithClientDto dto)
    {
        var account = await _accountRepository.GetWithClientByIdAsync(id);
        if (account == null)
            return false;

        account.Username = dto.Username;
        account.PasswordHash = dto.PasswordHash;

        if (account.Client != null)
        {
                account.Client.FirstName = dto.FirstName;
          account.Client.LastName = dto.LastName;
          account.Client.Age = dto.Age;
          account.Client.Sex = dto.Sex;
        }

        await _accountRepository.UpdateAsync(account);
        return true;
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