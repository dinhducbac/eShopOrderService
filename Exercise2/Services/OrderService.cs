using eShopOrderService.Entity;
using eShopOrderService.Respository;
using Exercise2.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace eShopOrderService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<APIResult<Order>> CreateOrder(int userId, int productId, int amount)
        {
            var order = new Order()
            {
                UserId = userId,
                ProductId = productId,
                Amount = amount
            };
            var result = await _orderRepository.CreateAsync(order);
            return new APIResult<Order>() { Success = true, Message = "Success", ResultObject = order };
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if(order == null)
                return false;
            await _orderRepository.DeleteAsync(order);
            return true;
        }

        public async Task<APIResult<List<Order>>> GetOrder(int userId)
        {
            var result = await _orderRepository.GetOrder(userId);
            return new APIResult<List<Order>>() { Success = true, Message = "Success", ResultObject = result };
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }
    }
}
