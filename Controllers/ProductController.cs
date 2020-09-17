using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestGreenAtom.Services;
using TestGreenAtom.ViewModels;

namespace TestGreenAtom.Controllers
{
    [Route("api/v1/products/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();

            return new JsonResult(products);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);

            return new JsonResult(product);
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM product)
        {
            await _productService.AddProduct(product);

            return new JsonResult("product was added");
        }

        [HttpPut("change")]
        public async Task<IActionResult> ChangeProduct(ProductVM product)
        {
            await _productService.ChangeProduct(product);

            return new JsonResult("Product was changed");
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProduct(id);

            return new JsonResult("Product was deleted");
        }
    }
}
