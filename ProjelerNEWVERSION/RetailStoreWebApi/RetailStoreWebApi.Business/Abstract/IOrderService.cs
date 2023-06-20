using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Business.Abstract
{
    public interface IOrderService
    {
        List<OrderGetModel>? GetAllOrders();

        OrderGetModel? GetOrderById(int orderId);

        OrderGetModel? AddNewOrder(OrderPostModel orderPostModel);

        OrderGetModel? DeactivateOrder(int orderId);
    }
}
