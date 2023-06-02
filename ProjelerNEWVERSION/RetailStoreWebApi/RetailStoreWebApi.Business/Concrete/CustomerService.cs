using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels;
using AutoMapper;

namespace RetailStoreWebApi.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerServiceDal _customerServiceDal;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerServiceDal customerServiceDal, IMapper mapper)
        {
            _customerServiceDal = customerServiceDal;
            _mapper = mapper;
        }

        public List<CustomerGetModel>? GetAllCustomers()
        {
            var customers = _customerServiceDal.GetAllCustomersDal();
            var customersGetModel = _mapper.Map<List<Customer>, List<CustomerGetModel>>(customers);
            return customersGetModel.Count == 0 ? null : customersGetModel;
        }

        public CustomerGetModel? GetCustomerById(int id)
        {
            var customer = _customerServiceDal.GetCustomerByIdDal(id);
            var customerGetModel = _mapper.Map<CustomerGetModel>(customer);
            return customerGetModel ?? null;
        }

        public List<Order>? GetOrdersByCustomerId(int id)
        {
            var orders = _customerServiceDal.GetOrdersByCustomerIdDal(id);
            return orders.Count == 0 ? null : orders;
        }

    }
}
