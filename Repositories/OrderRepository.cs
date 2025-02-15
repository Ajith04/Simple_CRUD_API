using DotNetCRUD.Database;
using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ABCDbContext _abcDbContext;

        public OrderRepository(ABCDbContext abcDbContext)
        {
            _abcDbContext = abcDbContext;
        }

        public async Task addNewOrder(Order order)
        {
            await _abcDbContext.AddAsync(order);
            await _abcDbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> getAllOrders()
        {
            var allOrders = await _abcDbContext.Orders.ToListAsync();
            return allOrders;
        }


        public async Task<Order> getOrderById(int id)
        {
            var singleOrder = await _abcDbContext.Orders.SingleOrDefaultAsync(r => r.OrderId == id);
            return singleOrder;
        }

        public async Task editOrder(Order order)
        {
            _abcDbContext.Orders.Update(order);
            await _abcDbContext.SaveChangesAsync();
        }

        public async Task deleteOrderById(Order order)
        {
            _abcDbContext.Orders.Remove(order);
            await _abcDbContext.SaveChangesAsync();
        }
    }
}
