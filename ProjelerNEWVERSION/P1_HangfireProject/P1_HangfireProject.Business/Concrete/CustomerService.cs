using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.Core.Entities.Models;
using P1_HangfireProject.DataAccess.Abstract;

namespace P1_HangfireProject.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        ICustomerServiceDal _customerServiceDal;

        public CustomerService(ICustomerServiceDal customerServiceDal)
        {
            _customerServiceDal = customerServiceDal;
        }

        public List<Customer> GetCustomersWithNonStandardBalance()
        {
            var data = _customerServiceDal.GetCustomersWithNonStandardBalanceDal();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }
    }
}
