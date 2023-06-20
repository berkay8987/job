using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetailGetModel>? GetAllOrderDetails();

        OrderDetailGetModel? GetOrderDetailById(int orderDetailId);

        OrderDetailGetModel? AddNewOrderDetail(OrderDetailPostModel orderDetailPostModel);

        OrderDetailGetModel? DeactivateOrderDetail(int orderDetailId);
    }
}
