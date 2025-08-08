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
    /// Constants for Country
    /// </summary>
    private const int IsoNameMaxLength = 100;
    private const int Iso2MaxLength = 2;
    private const int Iso3MaxLength = 3;
    private const int PhoneCodeMaxLength = 10;

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
    [MaxLength(IsoNameMaxLength)]
    [Comment("Official ISO name of the country.")]
    public string IsoName { get; set; }

    /// <summary>
    /// 2-letter ISO code.
    /// </summary>
    [Required]
    [MaxLength(Iso2MaxLength)]
    [Comment("2-letter ISO code.")]
    public string Iso2 { get; set; }

    /// <summary>
    /// 3-letter ISO code.
    /// </summary>
    [Required]
    [MaxLength(Iso3MaxLength)]
    [Comment("3-letter ISO code.")]
    public string Iso3 { get; set; }

    /// <summary>
    /// International phone code 
    /// </summary>
    [Required]
    [MaxLength(PhoneCodeMaxLength)]
    [Comment("International phone code")]
    public string PhoneCode { get; set; }
}
