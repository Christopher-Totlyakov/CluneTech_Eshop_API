using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;

/// <summary>
/// Represents a user account used for authentication.
/// </summary>
[Comment("Represents a user account used for authentication.")]
public class Account
{
    /// <summary>
    /// Constants for Account
    /// </summary>
    private const int UsernameMaxLength = 50;
    private const int PasswordHashMaxLength = 100;

    /// <summary>
    /// Unique identifier for the account.
    /// </summary>
    [Key]
    [Comment("Primary key of the account.")]
    public long Id { get; set; }

    /// <summary>
    /// Username for login.
    /// </summary>
    [Required]
    [MaxLength(UsernameMaxLength)]
    [Comment("Username for login.")]
    public string Username { get; set; }

    /// <summary>
    /// Hashed password for secure authentication.
    /// </summary>
    [Required]
    [MaxLength(PasswordHashMaxLength)]
    [Comment("Hashed password used for secure login.")]
    public string PasswordHash { get; set; }

    /// <summary>
    /// Associated client (1:1 relationship).
    /// </summary>
    [Comment("Associated client entity for this account.")]
    public Client Client { get; set; }
}
