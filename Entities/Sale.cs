using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entities;

/// <summary>
/// Represents a product sale made by a client.
/// </summary>
[Comment("Represents a product sale made by a client.")]
public class Sale
{
    /// <summary>
    /// Primary key of the sale.
    /// </summary>
    [Key]
    [Comment("Primary key of the sale.")]
    public long Id { get; set; }

    /// <summary>
    /// Client who made the purchase.
    /// </summary>
    [Required]
    [Comment("Client who made the purchase.")]
    public Client Client { get; set; }

    /// <summary>
    /// Product that was sold.
    /// </summary>
    [Required]
    [Comment("Product that was sold.")]
    public Product Product { get; set; }

    /// <summary>
    /// Quantity of the product sold.
    /// </summary>
    [Required]
    [Comment("Quantity of the product sold.")]
    public double Quantity { get; set; }

    /// <summary>
    /// Date and time when the order was placed.
    /// </summary>
    [Required]
    [Comment("Date and time when the order was placed.")]
    public DateTime OrderDate { get; set; }
}
