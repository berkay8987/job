using AutoMapper;
using RetailStoreWebApp.Business.Abstract;
using RetailStoreWebApp.Core.Entities.ViewModels;
using RetailStoreWebApp.Core.Entities.Models;
using RetailStoreWebApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerServiceDal _customerServiceDal;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerServiceDal customerServiceDal,
            IMapper mapper)
        {
            _customerServiceDal = customerServiceDal;
            _mapper = mapper;
        }

        public List<CustomerGetModel> GetAllCustomers()
        {
            var customers = _customerServiceDal.GetAllCustomersDal();
            var customersGetModel = _mapper.Map<List<Customer>, List<CustomerGetModel>>(customers);
            return customersGetModel;
        }

        public CustomerGetModel GetCustomerById(int id)
        {
            var customer = _customerServiceDal.GetCustomerByIdDal(id);
            var customerGetModel = _mapper.Map<CustomerGetModel>(customer);
            return customerGetModel;
        }

        public void ChangeCustomerEmail(CustomerPutModel customerPutModel)
        {
            var customer = _customerServiceDal.GetCustomerByIdDal(customerPutModel.CustomerId);
            
            // If user inputs the same email
            if (customer.Email == customerPutModel.Email)
            {
                return;
            }

            // If the email is already used
            var tempCustomer = _customerServiceDal.GetCustomerByEmailDal(customerPutModel.Email);
            if (tempCustomer != null)
            {
                return;
            }

            _customerServiceDal.ChangeCustomerEmailDal(customer, customerPutModel.Email);
        }

        public void DeactivateCustomer(int id)
        {
            var customerToDelete = _customerServiceDal.GetCustomerByIdDal(id);
            _customerServiceDal.DeactivateCustomerDal(customerToDelete);
        }

        public void AddNewCustomer(CustomerPostModel customerPostModel)
        {
            // If a user exists in the db with the same email but is inactive, reactivate it.
            var tempCustomer1 = _customerServiceDal.GetInactiveCustomerByEmailDal(customerPostModel.Email);
            if (tempCustomer1 != null)
            {
                _customerServiceDal.ReactivateCustomerDal(tempCustomer1);
                return;
            }

            // If user exists
            var tempCustomer2 = _customerServiceDal.GetCustomerByEmailDal(customerPostModel.Email);
            if (tempCustomer2 != null)
            {
                return;
            }

            var customerToAdd = _mapper.Map<Customer>(customerPostModel);
            _customerServiceDal.AddNewCustomerDal(customerToAdd);
        }
    }
}
