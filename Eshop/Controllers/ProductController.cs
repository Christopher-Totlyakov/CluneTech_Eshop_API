using Contracts.Repository;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models.Products;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


/// <summary>
/// Controller for managing products - CRUD operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;

    /// <summary>
    /// Constructor for ProductController, injecting the product service.
    /// </summary>
    /// <param name="productService">Service to handle product-related operations</param>
    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }

    /// <summary>
    /// Retrieves all products asynchronously.
    /// </summary>
    /// <returns>List of all products or NotFound if no products exist</returns>
    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAll()
    {
        var allProducts = await productService.GetAllAsync();
        if (!allProducts.Any())
            return NotFound(new { message = "No products found." });

        return Ok(allProducts);
    }

    /// <summary>
    /// Retrieves a specific product by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve</param>
    /// <returns>The product with the specified ID or NotFound if it doesn't exist</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(long id)
    {
        var product = await productService.GetByIdAsync(id);
        if (product == null)
            return NotFound(new { message = $"No product found with ID {id}" });

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product asynchronously.
    /// </summary>
    /// <param name="productDto">Data transfer object containing product details</param>
    /// <returns>The created product with a 201 Created response</returns>
    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        var createdProduct = await productService.CreateAsync(productDto);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }

    /// <summary>
    /// Updates an existing product asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product to update</param>
    /// <param name="productDto">Data transfer object containing updated product details</param>
    /// <returns>NoContent if update succeeded; NotFound if the product doesn't exist</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, ProductDto productDto)
    {
        var updated = await productService.UpdateAsync(id, productDto);
        if (!updated)
            return NotFound(new { message = $"No product found with ID {id}" });

        return NoContent();
    }

    /// <summary>
    /// Deletes a product asynchronously by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete</param>
    /// <returns>NoContent if deletion succeeded; NotFound if the product doesn't exist</returns>
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await productService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"No product found with ID {id}" });

        return NoContent();
    }
}