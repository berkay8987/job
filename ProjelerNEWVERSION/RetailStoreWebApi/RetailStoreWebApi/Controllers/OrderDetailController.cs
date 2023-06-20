using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;

namespace RetailStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("GetAllOrderDetails")]
        public ActionResult<List<OrderDetailGetModel>?> GetAllOrderDetails()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            return orderDetails == null ?
                BadRequest("No order detail found") :
                orderDetails;
        }

        [HttpGet("GetOrderDetailById/{orderDetailId}")]
        public ActionResult<OrderDetailGetModel?> GetOrderDetailById(int orderDetailId)
        {
            var orderDetail = _orderDetailService.GetOrderDetailById(orderDetailId);
            return orderDetail == null ?
                BadRequest("Not Found!") :
                orderDetail;
        }

        [HttpPost("AddNewOrderDetail")]
        public ActionResult<OrderDetailGetModel?> AddNewOrderDetail([FromBody] OrderDetailPostModel orderDetailPostModel)
        {
            var orderDetail = _orderDetailService.AddNewOrderDetail(orderDetailPostModel);
            return orderDetail == null ?
                BadRequest("Couldn't find the corresponding order or order detail already exists") :
                orderDetail;
        }

        [HttpDelete("DeleteOrderDetail/{orderDetailId}")]
        public ActionResult<OrderDetailGetModel?> DeleteOrderDetail(int orderDetailId)
        {
            return _orderDetailService.DeactivateOrderDetail(orderDetailId) == null ?
                BadRequest("OrderDetail doesn't exist") : 
                _orderDetailService.DeactivateOrderDetail(orderDetailId);
        }
    }
}
