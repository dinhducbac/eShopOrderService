using EmployeeManagerment.RabbitMQ;
using eShopOrderService.Models;
using eShopOrderService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IRabbitMQManager _rabbitMQManager;

        public OrderController(IOrderService orderService, IRabbitMQManager rabbitMQManager)
        {
            _orderService = orderService;
            _rabbitMQManager = rabbitMQManager;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateRequest orderCreateRequest)
        {
            var result = await _orderService.CreateOrder(orderCreateRequest.UserId, orderCreateRequest.ProductId,
                orderCreateRequest.Amount);
            _rabbitMQManager.Publish(new ChangeAmountRequest()
            {
                Id = orderCreateRequest.ProductId,
                Amount = - orderCreateRequest.Amount
            }, "changeAmount", "topic", "changeAmount");
            return Ok(result);
        }
        [HttpGet("get-order")]
        public async Task<IActionResult> GetOrder(int userId)
        {
            var result = await _orderService.GetOrder(userId);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            _rabbitMQManager.Publish(new ChangeAmountRequest()
            {
                Id = order.ProductId,
                Amount = order.Amount
            }, "changeAmount", "topic", "changeAmount");
            var result = await _orderService.DeleteOrder(id);
            return Ok(result);
        }
        public class ChangeAmountRequest
        {
            public int Id { get; set; }
            public int Amount { get; set; }
        }
       

    }
}
