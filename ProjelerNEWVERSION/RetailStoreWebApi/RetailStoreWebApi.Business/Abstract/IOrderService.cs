using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.ApiModels;

namespace RetailStoreWebApi.Business.Abstract
{
    public interface IOrderService
    {
        List<OrderGetModel>? GetAllOrders();

        OrderGetModel? GetOrderById(int id);
    }
}
