using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;

namespace RetailStoreWebApi.Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerGetModel>? GetAllCustomers();

        CustomerGetModel? GetCustomerById(int customerId);

        CustomerGetModel? UpdateCustomer(int customerId, string email);

        CustomerGetModel? AddNewCustomer(CustomerPostModel customerPostModel);

        CustomerGetModel? DeactivateCustomer(int customerId);
    }
}
