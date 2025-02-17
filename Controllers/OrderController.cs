using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _iOrderService;

        public OrderController(IOrderService iOrderService)
        {
            _iOrderService = iOrderService;
        }

        [HttpPost ("add-new-order")]
        public async Task<IActionResult> addNewOrder(OrderRequestDTO orderRequestDTO)
        {
            await _iOrderService.addNewOrder(orderRequestDTO);
            return Ok();
        }

        [HttpGet ("get-all-orders")]
        public async Task<IActionResult> getAllOrders()
        {
            var allOrders = await _iOrderService.getAllOrders();
            return Ok(allOrders);
        }

        [HttpGet ("get-order-by-id/{id}")]
        public async Task<IActionResult> getOrderById(int id)
        {
            var singleOrder = await _iOrderService.getOrderbyId(id);
            return Ok(singleOrder);
        }

        [HttpPut ("edit-order/{id}")]
        public async Task<IActionResult> editOrder(int id, OrderRequestDTO orderRequestDTO)
        {
            await _iOrderService.editOrder(id, orderRequestDTO);
            return Ok();
        }

        [HttpDelete ("delete-order-by-id/{id}")]
        public async Task<IActionResult> deleteOrderById(int id)
        {
            await _iOrderService.deleteOrderById(id);
            return Ok();
        }
    }
}
