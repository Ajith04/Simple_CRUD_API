using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> Add(EmployeeRequestDto dto)
        {
            var employee = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EmployeeRequestDto dto) =>
            await _service.UpdateAsync(id, dto) is EmployeeResponseDto emp ? Ok(emp) : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}

