using Contracts.Repository.ProductManagement;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Entities.Product> allProducts = await productRepository.GetAllAsync();

        if (!allProducts.Any())
        {
            return NotFound("No products found.");
        }

        return Ok(allProducts);
    }

    /// <summary>
    /// Gets a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The product with the given ID.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(long id)
    {
        Product product = await productRepository.GetAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound($"No product found with ID {id}");
        }

        return Ok(product);
    }


}