using EmployeeManagerment.Respository;
using eShopOrderService.Entity;
using Exercise2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopOrderService.Respository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<List<Order>> GetOrder(int userId);
    }
}
