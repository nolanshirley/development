using Interview.Web.Dtos;
using Interview.Web.Interfaces;
using Interview.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// I would create another controller for handling inventory

namespace Interview.Web.Controllers
{
    [Authorize]
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(
                       IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet("all")]
        public Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return _productService.GetAllProductsAsync();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            return Ok(_productService.AddProductAsync(product));
        }

        [HttpGet("searchNames")]
        public async Task<IActionResult> SearchProductNames([FromQuery] string searchText)
        {

            return Ok(_productService.SearchProductsAsync(searchText));
        }
    }
}
