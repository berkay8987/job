using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;

namespace RetailStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public ActionResult<List<OrderGetModel>?> GetAllOrders()
        {
            return _orderService.GetAllOrders() == null ?
                BadRequest("No order") :
                _orderService.GetAllOrders();
        }

        [HttpGet("GetOrderById/{orderId}")]
        public ActionResult<OrderGetModel?> GetOrderById(int orderId)
        {
            return _orderService.GetOrderById(orderId) == null ?
                BadRequest("Order not found!") :
                _orderService.GetOrderById(orderId);
        }

        [HttpPost("AddNewOrder")]
        public ActionResult<OrderGetModel?> AddNewOrder([FromBody] OrderPostModel orderPostModel)
        {
            return _orderService.AddNewOrder(orderPostModel);
        }

        [HttpDelete("DeleteOrder/{orderId}")]
        public ActionResult<OrderGetModel?> DeleteOrder(int orderId)
        {
            return _orderService.DeactivateOrder(orderId) == null ? 
                BadRequest("Order not found!") :
                _orderService.DeactivateOrder(orderId);
        }
    }
}
