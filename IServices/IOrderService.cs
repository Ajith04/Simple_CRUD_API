using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;

namespace DotNetCRUD.IServices
{
    public interface IOrderService
    {
        Task addNewOrder(OrderRequestDTO orderRequestDTO);
        Task<List<OrderResponseDTO>> getAllOrders();
        Task<OrderResponseDTO> getOrderbyId(int id);
        Task editOrder(int id, OrderRequestDTO orderRequestDTO);

        Task deleteOrderById(int id);
    }
}
