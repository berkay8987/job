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
        List<Order>? GetAllOrdersDal();

        Order? GetOrderByIdDal(int orderId);

        Order? AddNewOrderDal(Order order);

        void DeactivateOrder(Order order);
    }
}
