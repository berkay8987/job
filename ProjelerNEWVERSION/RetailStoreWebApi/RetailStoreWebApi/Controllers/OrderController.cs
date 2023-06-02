using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreWebApi.Core.Entities.ApiModels;
using RetailStoreWebApi.Business.Abstract;

namespace RetailStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public List<OrderGetModel>? GetOrders()
        {
            return _orderService.GetAllOrders();
        }
    }
}
