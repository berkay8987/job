using RetailStoreWebApp.Core.Entities.Models;
using RetailStoreWebApp.Core.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerGetModel> GetAllCustomers();

        CustomerGetModel GetCustomerById(int id);

        void ChangeCustomerEmail(CustomerPutModel customerPostModel);

        void DeactivateCustomer(int id);

        void AddNewCustomer(CustomerPostModel customerPostModel);
    }
}
