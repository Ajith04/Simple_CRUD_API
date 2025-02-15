using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.IServices;
using DotNetCRUD.Models;

namespace DotNetCRUD.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _iOrderRepository;

        public OrderService(IOrderRepository iOrderRepository)
        {
            _iOrderRepository = iOrderRepository;
        }

        public async Task addNewOrder(OrderRequestDTO orderRequestDTO)
        {
            var order = new Order()
            {
                Name = orderRequestDTO.Name,
                Description = orderRequestDTO.Description,
                Date = orderRequestDTO.Date,
            };

            await _iOrderRepository.addNewOrder(order);
        }

        public async Task<List<OrderResponseDTO>> getAllOrders()
        {
            var allOrders = await _iOrderRepository.getAllOrders();

            var orderList = new List<OrderResponseDTO>();
            foreach (var order in allOrders)
            {
                var responseDTO = new OrderResponseDTO()
                {
                    Name=order.Name,
                    Description=order.Description,
                    Date = order.Date,
                };

                orderList.Add(responseDTO);
            }

            return orderList;
        }

        public async Task<OrderResponseDTO> getOrderbyId(int id)
        {
            var singleOrder = await _iOrderRepository.getOrderById(id);

            var orderResponse = new OrderResponseDTO()
            {
               Name = singleOrder.Name,
               Description = singleOrder.Description,
               Date = singleOrder.Date,
            };

            return orderResponse;
        }

        public async Task editOrder(int id, OrderRequestDTO orderRequestDTO)
        {

            var singleOrder = await _iOrderRepository.getOrderById(id);
            if (singleOrder != null)
            {
                singleOrder.Name = orderRequestDTO.Name;
                singleOrder.Description = orderRequestDTO.Description;
                singleOrder.Date = orderRequestDTO.Date;

                await _iOrderRepository.editOrder(singleOrder);
            }           

        }

        public async Task deleteOrderById(int id)
        {
            var deleteOrder = await _iOrderRepository.getOrderById(id);

            if(deleteOrder != null)
            {
                await _iOrderRepository.deleteOrderById(deleteOrder);
            }
        }
    }
}
