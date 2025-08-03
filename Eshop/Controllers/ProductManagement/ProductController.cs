using Contracts.Repository.ProductManagement;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers.ProductManagement;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    /// <summary>
    /// Repository for Product domain object
    /// </summary>
    private readonly IProductRepository productRepository;

    /// <summary>
    /// Initializes a new instance of <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="productRepository">The Product repository.</param>
    public ProductController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetAllProducts")]
    public IActionResult GetAll()
    {
        IEnumerable<Entities.Product> allProducts = productRepository.GetAll();

        if (!allProducts.Any())
        {
            return NotFound("No products found.");
        }

        return Ok(allProducts);
    }

    // GetProductById - Get, AddProduct - Post
}