using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entities;

/// <summary>
/// Represents a product available for sale.
/// </summary>
[Comment("Represents a product available for sale.")]
public class Product
{
    /// <summary>
    /// Primary key of the product.
    /// </summary>
    [Key]
    [Comment("Primary key of the product.")]
    public long Id { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Comment("Name of the product.")]
    public string Name { get; set; }

    /// <summary>
    /// Type or category of the product.
    /// </summary>
    [Required]
    [MaxLength(50)]
    [Comment("Type or category of the product.")]
    public string Type { get; set; }

    /// <summary>
    /// Price of the product.
    /// </summary>
    [Required]
    [Comment("Price of the product in the applicable currency.")]
    public decimal Price { get; set; }
}
