using eShopOrderService.Entity;
using Exercise2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopOrderService.Services
{
    public interface IOrderService
    {
        public Task<APIResult<Order>> CreateOrder(int userId, int productId, int amount);
        public Task<APIResult<List<Order>>> GetOrder(int userId);
        public Task<Order> GetOrderById(int id);
        public Task<bool> DeleteOrder(int id);
    }
}
