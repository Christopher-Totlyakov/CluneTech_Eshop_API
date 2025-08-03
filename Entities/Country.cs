using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entities;

/// <summary>
/// Represents a country, including ISO codes and phone code.
/// </summary>
[Comment("Represents a country, including ISO codes and phone code.")]
public class Country
{
    /// <summary>
    /// Primary key of the country.
    /// </summary>
    [Key]
    [Comment("Primary key of the country.")]
    public long Id { get; set; }

    /// <summary>
    /// Official ISO name of the country.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Comment("Official ISO name of the country.")]
    public string IsoName { get; set; }

    /// <summary>
    /// 2-letter ISO code.
    /// </summary>
    [Required]
    [MaxLength(2)]
    [Comment("2-letter ISO code.")]
    public string Iso2 { get; set; }

    /// <summary>
    /// 3-letter ISO code.
    /// </summary>
    [Required]
    [MaxLength(3)]
    [Comment("3-letter ISO code.")]
    public string Iso3 { get; set; }

    /// <summary>
    /// International phone code 
    /// </summary>
    [Required]
    [MaxLength(10)]
    [Comment("International phone code")]
    public string PhoneCode { get; set; }
}
