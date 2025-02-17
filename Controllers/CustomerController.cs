using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var data = await  _customerService.GetAllCustomer();
                return Ok(data);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var data = await _customerService.GetCustomer(id);
                return Ok(data);

            }

            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var data = await _customerService.DeleteCustomer(id);
                return Ok(data);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCusomer(CustomerReqDTO customerReqDTO)
        {
            try
            {
                var data = await _customerService.AddCustomer(customerReqDTO);
                return Ok(data);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("EditCustomer/{id}")]
        public async Task<IActionResult> EditCustomer(int id, CustomerReqDTO customerReqDTO) 
        {
            try
            {
                var data = await _customerService.UpdateCustomer(customerReqDTO, id);
                return Ok(data);
            }

            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
                
        }


    }



}
