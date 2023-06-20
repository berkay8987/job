using RetailStoreWebApi.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.DataAccess.Abstract
{
    public interface IOrderDetailServiceDal
    {
        List<OrderDetail>? GetAllOrderDetailsDal();

        OrderDetail? GetOrderDetailByIdDal(int orderDetaiId);

        OrderDetail? AddNewOrderDetailDal(OrderDetail orderDetail);

        bool CheckOrderAndDetail(int orderId);

        void DeactivateOrderDetailDal(OrderDetail orderDetail);
    }
}
