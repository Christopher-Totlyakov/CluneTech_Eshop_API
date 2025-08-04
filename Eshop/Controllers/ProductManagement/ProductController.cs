using Contracts.Repository.ProductManagement;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models.Products;
using Repository.ProductManagement;
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
    /// Constructor for ProductController with injected IProductService.
    /// </summary>
    /// <param name="productService">Service for product operations</param>
    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A collection of products or 404 if no products found.</returns>
    [HttpGet]
    [Route("GetAllProducts")]
    public async Task<IActionResult> GetAll()
    {
        var allProducts = await productService.GetAllAsync();

        if (!allProducts.Any())
            return NotFound("No products found.");

        return Ok(allProducts);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns>The product with the specified ID or 404 if not found.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(long id)
    {
        var product = await productService.GetByIdAsync(id);

        if (product == null)
            return NotFound($"No product found with ID {id}");

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="productDto">Data for creating the product.</param>
    /// <returns>The created product with HTTP 201 status.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        var createdProduct = await productService.CreateAsync(productDto);

        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }

}