using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PutModels;

namespace RetailStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public ActionResult<List<ProductGetModel>?> GetAllProducts()
        {
            return _productService.GetAllProducts() == null ? 
                BadRequest("No Product was found!") : 
                _productService.GetAllProducts();
        }

        [HttpGet("GetProductById/{productId}")]
        public ActionResult<ProductGetModel?> GetProductById(int productId)
        {
            return _productService.GetProductById(productId) == null ?
                BadRequest("Not found!") : 
                _productService.GetProductById(productId);
        }

        [HttpPut("UpdateProduct")]
        public ActionResult<ProductGetModel?> UpdateProduct([FromBody] ProductPutModel productPutModel)
        {
            var data = _productService.UpdateProduct(productPutModel.ProductId, productPutModel.Quantity, productPutModel.PriceUsd);
            return data == null ?
                BadRequest("Element not found!") :
                data;
        }
    }
}
