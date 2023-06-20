using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.DataAccess.Abstract;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;

namespace RetailStoreWebApi.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerServiceDal _customerServiceDal;

        public CustomerService(
            IMapper mapper,
            ICustomerServiceDal customerServiceDal)
        {
            _mapper = mapper;
            _customerServiceDal = customerServiceDal;
        }

        public List<CustomerGetModel>? GetAllCustomers()
        {
            var customers = _customerServiceDal.GetAllCustomersDal();
            var customersGetModel = _mapper.Map<List<Customer>, List<CustomerGetModel>>(customers);
            return customersGetModel ?? null;
        }

        public CustomerGetModel? GetCustomerById(int customerId)
        {
            var customer = _customerServiceDal.GetCustomerByIdDal(customerId);
            var customerGetModel = _mapper.Map<CustomerGetModel>(customer);
            return customerGetModel ?? null;
        }

        public CustomerGetModel? UpdateCustomer(int customerId, string email)
        {
            var existingCustomer = _customerServiceDal.GetCustomerByIdDal(customerId);
            if (existingCustomer == null)
            {
                return null;
            }
            var newCustomer = _customerServiceDal.UpdateCustomerDal(email, existingCustomer);
            var newCustomerGetModel = _mapper.Map<CustomerGetModel>(newCustomer);
            return newCustomerGetModel;
        }

        public CustomerGetModel? AddNewCustomer(CustomerPostModel customerPostModel)
        {
            /*
             * 1) Customer exists in the db but is inactive 
             * 2) Customer does not exists
             * 3) Customer already exists and active.
             */

            // Returns null if user does exits but is inactive.
            var customerInactive = _customerServiceDal.GetInactiveCustomerByEmailDal(customerPostModel.Email);

            // Returns null if user doesn't exist.
            var customerActive = _customerServiceDal.GetCustomerByEmailDal(customerPostModel.Email);

            // 1)
            if (customerInactive != null)
            {
                _customerServiceDal.ReactivateCustomerDal(customerInactive);
                var customerGetModel1 = _mapper.Map<CustomerGetModel>(customerInactive);
                return customerGetModel1 ?? null;
            }

            // 3)
            else if (customerActive != null)
            {
                var customerGetModel2 = _mapper.Map<CustomerGetModel>(customerActive);
                return customerGetModel2 ?? null;
            }

            // 2)
            var customerToAdd = _mapper.Map<Customer>(customerPostModel);
            var newCustomer = _customerServiceDal.AddNewCustomerDal(customerToAdd);
            var customerGetModel = _mapper.Map<CustomerGetModel>(newCustomer);
            return customerGetModel ?? null;
        }

        public CustomerGetModel? DeactivateCustomer(int customerId)
        {
            var customer = _customerServiceDal.GetCustomerByIdDal(customerId);
            if (customer == null)
            {
                return null;
            }
            _customerServiceDal.DeactivateCustomerDal(customer);

            var customerGetModel = _mapper.Map<CustomerGetModel>(customer);
            return customerGetModel;
        }
    }
}
