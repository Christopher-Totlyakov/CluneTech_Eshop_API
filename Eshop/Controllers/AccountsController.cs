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
    /// Retrieves all accounts.
    /// </summary>
    /// <returns>A list of all accounts.</returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var results = await _accountService.GetAllAsync();
        return Ok(results);
    }

}