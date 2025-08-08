using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;

/// <summary>
/// Represents a client who can place orders.
/// </summary>
[Comment("Represents a client who can place orders.")]
public class Client
{
    /// <summary>
    /// Constants for Client
    /// </summary>
    private const int FirstNameMaxLength = 50;
    private const int LastNameMaxLength = 50;
    private const int SexMaxLength = 10;

    /// <summary>
    /// Primary key of the client.
    /// </summary>
    [Key]
    [Comment("Primary key of the client.")]
    public long Id { get; set; }

    /// <summary>
    /// Associated user account.
    /// </summary>
    [Comment("Associated user account.")]
    public Account Account { get; set; }

    /// <summary>
    /// Foreign key to the Account table.
    /// </summary>
    [ForeignKey(nameof(Account))]
    [Comment("Foreign key referencing the related account.")]
    public long AccountId { get; set; }

    /// <summary>
    /// Client's first name.
    /// </summary>
    [Required]
    [MaxLength(FirstNameMaxLength)]
    [Comment("Client's first name.")]
    public string FirstName { get; set; }

    /// <summary>
    /// Client's last name.
    /// </summary>
    [Required]
    [MaxLength(LastNameMaxLength)]
    [Comment("Client's last name.")]
    public string LastName { get; set; }

    /// <summary>
    /// Client's age.
    /// </summary>
    [Comment("Client's age.")]
    public int Age { get; set; }

    /// <summary>
    /// Client's gender.
    /// </summary>
    [MaxLength(SexMaxLength)]
    [Comment("Client's gender (e.g., Male, Female, Other).")]
    public string Sex { get; set; }

    /// <summary>
    /// List of addresses associated with the client.
    /// </summary>
    [Comment("List of addresses associated with the client.")]
    public List<Address> Addresses { get; set; }

    /// <summary>
    /// List of sales made by the client.
    /// </summary>
    [Comment("List of sales made by the client.")]
    public List<Sale> Sales { get; set; }
}
