using RetailStoreWebApp.Core.Entities.Models;
using RetailStoreWebApp.Core.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.DataAccess.Abstract
{
    public interface ICustomerServiceDal
    {
        List<Customer> GetAllCustomersDal();

        Customer? GetCustomerByIdDal(int id);

        Customer? GetInactiveCustomerByEmailDal(string email);

        Customer? GetCustomerByEmailDal(string email);

        void ChangeCustomerEmailDal(Customer customer, string email);

        void DeactivateCustomerDal(Customer customer);

        void ReactivateCustomerDal(Customer customer);

        void AddNewCustomerDal(Customer customer);
    }
}
