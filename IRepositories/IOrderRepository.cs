using DotNetCRUD.Models;

namespace DotNetCRUD.IRepositories
{
    public interface IOrderRepository
    {
        Task addNewOrder(Order order);
        Task<List<Order>> getAllOrders();
        Task<Order> getOrderById(int id);
        Task editOrder(Order order);
        Task deleteOrderById(Order order);
    }
}
