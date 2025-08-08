using Contracts.Repository;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Identity;
using Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public AccountService(IAccountRepository accountRepository, IPasswordHasher<Account> passwordHasher)
    {
        _accountRepository = accountRepository;
        _passwordHasher = passwordHasher;
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
        ValidateAccountDto(accountClientdto);

        var account = new Account
        {
            Username = accountClientdto.Username,
            Client = new Client
            {
                FirstName = accountClientdto.FirstName,
                LastName = accountClientdto.LastName,
                Age = accountClientdto.Age,
                Sex = accountClientdto.Sex
            }
        };
        account.PasswordHash = _passwordHasher.HashPassword(account, accountClientdto.PasswordHash);

        await _accountRepository.CreateAsync(account);
        return MapToResponseDto(account);
    }

    public async Task<bool> UpdateAsync(long id, AccountWithClientDto dto)
    {
        ValidateAccountDto(dto);

        var account = await _accountRepository.GetWithClientByIdAsync(id);
        if (account == null)
            return false;

        account.Username = dto.Username;
        if (account.Client != null)
        {
            account.Client.FirstName = dto.FirstName;
            account.Client.LastName = dto.LastName;
            account.Client.Age = dto.Age;
            account.Client.Sex = dto.Sex;
        }
        if (!string.IsNullOrWhiteSpace(dto.PasswordHash))
        {
            account.PasswordHash = _passwordHasher.HashPassword(account, dto.PasswordHash);
        }

        await _accountRepository.UpdateAsync(account);
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account == null)
            return false;

        await _accountRepository.DeleteAsync(account);
        return true;
    }

    public async Task<AccountResponseDto> LoginAsync(LoginDto loginDto)
    {
        var account = await _accountRepository.GetWithClientByUsernameAsync(loginDto.Username);

        if (account == null)
            return null;

        var passwordVerificationResult = _passwordHasher
            .VerifyHashedPassword(account, account.PasswordHash, loginDto.PasswordHash);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            return null;

        return MapToResponseDto(account);
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

    private void ValidateAccountDto(AccountWithClientDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Username))
            throw new ValidationException("Username is required.");

        if (string.IsNullOrWhiteSpace(dto.PasswordHash))
            throw new ValidationException("Password is required.");

        if (string.IsNullOrWhiteSpace(dto.FirstName))
            throw new ValidationException("First name is required.");

        if (string.IsNullOrWhiteSpace(dto.LastName))
            throw new ValidationException("Last name is required.");

        if (dto.Age < 0 || dto.Age > 120)
            throw new ValidationException("Age must be between 0 and 120.");

        if (string.IsNullOrWhiteSpace(dto.Sex))
            throw new ValidationException("Sex is required.");
    }
}