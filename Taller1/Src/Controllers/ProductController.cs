using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Models;
using Taller1.Src.Services.Implements;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Controllers
{
    [ApiController]
    //[Authorize(Roles= "Admin")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var result = _productService.GetProducts().Result;
            return Ok(result);
        }
    }
}