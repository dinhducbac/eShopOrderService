using EmployeeManagerment.Respository;
using eShopOrderService.Entity;
using Exercise2.EF;
using Exercise2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eShopOrderService.Respository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly eShopDBContext _dbContext;
        public OrderRepository(eShopDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Order>> GetOrder(int userId)
        {
            return await _dbContext.Orders.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
