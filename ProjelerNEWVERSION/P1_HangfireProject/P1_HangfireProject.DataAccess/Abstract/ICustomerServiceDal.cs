using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Core.Entities.Models;

namespace P1_HangfireProject.DataAccess.Abstract
{
    public interface ICustomerServiceDal
    {
        List<Customer> GetCustomersWithNonStandardBalanceDal();
    }
}
