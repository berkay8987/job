using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.ApiModels;
using RetailStoreWebApi.Core.Entities.Models;

namespace RetailStoreWebApi.Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerGetModel>? GetAllCustomers();

        CustomerGetModel? GetCustomerById(int id);

        List<Order>? GetOrdersByCustomerId(int id);
    }
}
