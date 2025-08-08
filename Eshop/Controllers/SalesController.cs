using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Sales;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _saleService.GetAllAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var sale = await _saleService.GetByIdAsync(id);
                return sale is null ? NotFound(new { message = "Sale not found." }) : Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(SaleDto saleDto)
        {
            try
            {
                var created = await _saleService.CreateAsync(saleDto);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, SaleDto dto)
        {
            try
            {
                var updated = await _saleService.UpdateAsync(id, dto);
                return updated ? NoContent() : NotFound(new { message = "Sale not found." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var deleted = await _saleService.DeleteAsync(id);
                return deleted ? NoContent() : NotFound(new { message = "Sale not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
    }
}
