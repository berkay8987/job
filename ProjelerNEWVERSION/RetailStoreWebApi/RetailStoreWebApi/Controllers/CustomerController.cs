using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApi.Core.Entities.ApiModels;
using RetailStoreWebApi.Business.Abstract;

namespace RetailStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public ActionResult<List<CustomerGetModel>> GetCustomers()
        {
            return _customerService.GetAllCustomers() == null 
                ? BadRequest("No Element Found") 
                : _customerService.GetAllCustomers();

            // This doesn't work.
            // return _customerService.GetAllCustomers() ?? BadRequest("No Element Found");
        }

        [HttpGet("GetCustomer/{id}")]
        public ActionResult<CustomerGetModel> GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id) == null
                ? BadRequest("No Element Found")
                : _customerService.GetCustomerById(id);
        }
    }
}
