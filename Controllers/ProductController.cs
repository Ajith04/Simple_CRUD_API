using DotNetCRUD.DTO.RequestDTO.Product;
using DotNetCRUD.IServices.IProductService;

using DotNetCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()=>Ok(await _productService.GetAllProductsAsync());
        

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestDTO product)
        {
                var data= await _productService.AddProductAsync(product);
                return Ok(data);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Products product)
        {
            _productService.UpdateProductAsync(product);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProductAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
