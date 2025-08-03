using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;

/// <summary>
/// Represents a physical address associated with a client.
/// </summary>
[Comment("Represents a physical address associated with a client.")]
public class Address
{
    /// <summary>
    /// Primary key of the address.
    /// </summary>
    [Key]
    [Comment("Primary key of the address.")]
    public long Id { get; set; }

    /// <summary>
    /// Client who owns the address.
    /// </summary>
    [Comment("Client who owns the address.")]
    public Client Client { get; set; }

    /// <summary>
    /// Foreign key referencing the client.
    /// </summary>
    [ForeignKey(nameof(Client))]
    [Comment("Foreign key referencing the client.")]
    public long ClientId { get; set; }

    /// <summary>
    /// Country where the address is located.
    /// </summary>
    [Comment("Country where the address is located.")]
    public Country Country { get; set; }

    /// <summary>
    /// Foreign key referencing the country.
    /// </summary>
    [ForeignKey(nameof(Country))]
    [Comment("Foreign key referencing the country.")]
    public long CountryId { get; set; }

    /// <summary>
    /// City name.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Comment("City where the address is located.")]
    public string City { get; set; }

    /// <summary>
    /// Street name.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Comment("Street name of the address.")]
    public string Street { get; set; }

    /// <summary>
    /// Street number or apartment number.
    /// </summary>
    [Required]
    [MaxLength(20)]
    [Comment("Street number or apartment number.")]
    public string Number { get; set; }

    /// <summary>
    /// Indicates whether this is the client's main address.
    /// </summary>
    [Comment("Indicates whether this is the client's main address.")]
    public bool IsMain { get; set; }
}
