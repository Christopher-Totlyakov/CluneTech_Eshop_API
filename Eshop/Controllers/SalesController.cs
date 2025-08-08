using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Sales;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Controllers
{
    /// <summary>
    /// Controller for managing sales operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        /// <summary>
        /// Constructor for SalesController, injecting the sale service.
        /// </summary>
        /// <param name="saleService">Service to handle sales operations</param>
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Retrieves all sales asynchronously.
        /// </summary>
        /// <returns>List of all sales</returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _saleService.GetAllAsync();
            return Ok(list);
        }

        /// <summary>
        /// Retrieves a specific sale by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the sale to retrieve</param>
        /// <returns>The sale with the specified ID or NotFound if it doesn't exist</returns>
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var sale = await _saleService.GetByIdAsync(id);
            return sale is null ? NotFound(new { message = "Sale not found." }) : Ok(sale);
        }

        /// <summary>
        /// Creates a new sale asynchronously.
        /// </summary>
        /// <param name="saleDto">Data transfer object containing sale details</param>
        /// <returns>The created sale with a 201 Created response</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(SaleDto saleDto)
        {
            var created = await _saleService.CreateAsync(saleDto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing sale asynchronously.
        /// </summary>
        /// <param name="id">The ID of the sale to update</param>
        /// <param name="saleDto">Data transfer object containing updated sale details</param>
        /// <returns>NoContent if update succeeded; NotFound if the sale doesn't exist</returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, SaleDto saleDto)
        {
            var updated = await _saleService.UpdateAsync(id, saleDto);
            return updated ? NoContent() : NotFound(new { message = "Sale not found." });
        }

        /// <summary>
        /// Deletes a sale asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the sale to delete</param>
        /// <returns>NoContent if deletion succeeded; NotFound if the sale doesn't exist</returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _saleService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound(new { message = "Sale not found." });
        }
    }
}
