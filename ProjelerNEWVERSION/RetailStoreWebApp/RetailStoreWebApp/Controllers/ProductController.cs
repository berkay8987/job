using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApp.Business.Abstract;
using RetailStoreWebApp.Core.Entities.ViewModels;

namespace RetailStoreWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_productService.GetAllProducts());
        }

        // GET
        public IActionResult Edit(int id)
        {
            return View(_productService.GetProductById(id));
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductPutModel productPutModel)
        {
            _productService.UpdateProduct(productPutModel);
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Delete(int id)
        {
            return View(_productService.GetProductById(id));
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            _productService.DeactivateProduct(id);
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductPostModel productPostModel)
        {
            _productService.AddNewProduct(productPostModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
