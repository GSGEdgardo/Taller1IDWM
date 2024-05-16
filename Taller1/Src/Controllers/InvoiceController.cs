using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller1.Src.DTOs;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }



        [HttpPost("buy")]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice([FromBody] BuyProductDto buyProductDto)
        {
            try
            {
                var invoice = await _invoiceService.CreateInvoice(buyProductDto.ProductId, buyProductDto.Quantity);
                return CreatedAtAction(nameof(GetAllInvoices), new { id = invoice.Id }, invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
