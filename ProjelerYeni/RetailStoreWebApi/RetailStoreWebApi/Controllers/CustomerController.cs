using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PutModels;

namespace RetailStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public ActionResult<List<CustomerGetModel>?> GetAllCustomers()
        {
            return _customerService.GetAllCustomers() == null ?
                BadRequest("No Customer was found!") :
                _customerService.GetAllCustomers();
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public ActionResult<CustomerGetModel?> GetCustomerById(int customerId)
        {
            return _customerService.GetCustomerById(customerId) == null ?
                BadRequest("Element Not Found!") :
                _customerService.GetCustomerById(customerId);
        }

        [HttpPut("UpdateCustomer")]
        public ActionResult<CustomerGetModel?> UpdateCustomer([FromBody] CustomerPutModel customerPutModel)
        {
            var data = _customerService.UpdateCustomer(customerPutModel.CustomerId, customerPutModel.Email);
            return data == null ?
                BadRequest("Element Not Found!") :
                data;
        }

        [HttpPost("AddNewCustomer")]
        public ActionResult<CustomerGetModel?> AddNewCustomer([FromBody] CustomerPostModel customerPostModel)
        {
            var data = _customerService.AddNewCustomer(customerPostModel);
            return data == null ?
                BadRequest("Couldn't Add Customer, Either it already exists or something else went wrong.") :
                data;
        }

        [HttpDelete("DeleteCustomer/{customerId}")]
        public ActionResult<CustomerGetModel?> DeleteCustomer(int customerId)
        {
            return _customerService.DeactivateCustomer(customerId) == null ?
                BadRequest("Couldn't delete customer") :
                _customerService.DeactivateCustomer(customerId);
        }
    }
}
