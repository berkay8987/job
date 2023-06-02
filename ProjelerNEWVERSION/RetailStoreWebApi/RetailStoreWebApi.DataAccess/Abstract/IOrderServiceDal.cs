using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.Models;

namespace RetailStoreWebApi.DataAccess.Abstract
{
    public interface IOrderServiceDal
    {
        List<Order> GetAllOrders();

        Order GetOrderById(int id);
    }
}
