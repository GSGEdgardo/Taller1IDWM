using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller1.Src.DTOs;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Models;
using Taller1.Src.Services.Implements;
using Taller1.Src.Services.Interfaces;


namespace Taller1.Src.Controllers
{
    [ApiController]
    [Authorize(Roles= "Admin")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IInvoiceService _invoiceService;

        public ProductController(IProductService productService, IInvoiceService invoiceService)
        {
            _productService = productService;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var result = _productService.GetProducts().Result;
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult<string> EditProduct(int id, [FromBody] EditProductDto editProduct)
        {
            var result = _productService.EditProduct(id, editProduct).Result;
            if (!result)
            {
                return NotFound("El producto no existe en el sistema.");
            }
            return Ok("El producto se editó correctamente");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id).Result;
            if (!result)
            {
                return NotFound("El producto no existe en el sistema.");
            }
            return Ok("El producto se eliminó correctamente");
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateProduct(CreateProductDto createProductDto)
        {
            try
            {
                var response = await _productService.CreateProduct(createProductDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}