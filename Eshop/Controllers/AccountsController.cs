using Microsoft.AspNetCore.Mvc;
using Contracts.Services;
using Models.Accounts;

namespace Eshop.Controllers;

/// <summary>
/// Controller for managing account-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountsController"/> class.
    /// </summary>
    /// <param name="accountService">The account service.</param>
    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }


    /// <summary>
    /// Retrieves an account by ID.
    /// </summary>
    /// <param name="id">The ID of the account.</param>
    /// <returns>The account if found; otherwise, 404 Not Found.</returns>
    [HttpGet("getBy/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var result = await _accountService.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Retrieves all accounts.
    /// </summary>
    /// <returns>A list of all accounts.</returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var results = await _accountService.GetAllAsync();
        return Ok(results);
    }


    /// <summary>
    /// Creates a new account with associated client data.
    /// </summary>
    /// <param name="accountClientDto">The account and client data.</param>
    /// <returns>The created account with 201 Created status.</returns>
    [HttpPost("create")]
    public async Task<IActionResult> Create(AccountWithClientDto accountClientDto)
    {
        var created = await _accountService.CreateAsync(accountClientDto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    /// <summary>
    /// Updates an account and its related client.
    /// </summary>
    /// <param name="id">The ID of the account to update.</param>
    /// <param name="AccountClientDto">The updated account and client data.</param>
    /// <returns>No content if successful, or 404 if not found.</returns>
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(long id, AccountWithClientDto AccountClientDto)
    {
        var updated = await _accountService.UpdateAsync(id, AccountClientDto);
        return updated ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes an account by its ID.
    /// </summary>
    /// <param name="id">The ID of the account to delete.</param>
    /// <returns>No content if successful, or 404 if not found.</returns>
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _accountService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    /// <summary>
    /// Authenticates a user with login credentials.
    /// </summary>
    /// <param name="loginDto">The login credentials.</param>
    /// <returns>The authenticated account if successful; otherwise, 401 Unauthorized.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _accountService.LoginAsync(loginDto);
        return result is null ? NotFound() : Ok(result);
    }
}