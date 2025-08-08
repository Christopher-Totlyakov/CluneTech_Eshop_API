using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Sales;

namespace Eshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Retrieves all sales with client and product details.
        /// </summary>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _saleService.GetAllAsync();
            return Ok(list);
        }

        /// <summary>
        /// Retrieves a sale by its ID.
        /// </summary>
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var sale = await _saleService.GetByIdAsync(id);
            return sale is null ? NotFound() : Ok(sale);
        }

        /// <summary>
        /// Creates a new sale.
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create(SaleDto saleDto)
        {
            SaleResponseDto created = await _saleService.CreateAsync(saleDto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing sale.
        /// </summary>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, SaleDto dto)
        {
            var updated = await _saleService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        /// <summary>
        /// Deletes a sale by ID.
        /// </summary>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _saleService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
