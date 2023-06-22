using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApp.Business.Abstract;
using RetailStoreWebApp.Core.Entities.ViewModels;

namespace RetailStoreWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        // GET
        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

        // GET
        public IActionResult Edit(int id)
        {
            return View(_customerService.GetCustomerById(id));
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerPutModel customerPostModel)
        {
            _customerService.ChangeCustomerEmail(customerPostModel);
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Delete(int id) 
        {
            return View(_customerService.GetCustomerById(id));
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            _customerService.DeactivateCustomer(id);
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
        public IActionResult Create(CustomerPostModel customerPostModel)
        {
            _customerService.AddNewCustomer(customerPostModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
