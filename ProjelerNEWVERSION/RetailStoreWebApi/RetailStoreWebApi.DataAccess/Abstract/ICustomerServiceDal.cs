using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.Models;

namespace RetailStoreWebApi.DataAccess.Abstract
{
    public interface ICustomerServiceDal
    {
        List<Customer>? GetAllCustomersDal();

        Customer? GetCustomerByIdDal(int customerId);

        Customer? GetInactiveCustomerByEmailDal(string email);

        Customer? GetCustomerByEmailDal(string email);

        Customer? UpdateCustomerDal(string email, Customer customer);

        Customer? AddNewCustomerDal(Customer customer);

        void ReactivateCustomerDal(Customer customer);

        void DeactivateCustomerDal(Customer customer);
    }
}
