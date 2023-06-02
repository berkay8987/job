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
        public List<CustomerGetModel>? GetCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("GetCustomer/{id}")]
        public CustomerGetModel? GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }
    }
}
