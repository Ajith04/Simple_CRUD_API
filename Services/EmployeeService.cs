using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.IServices;
using DotNetCRUD.Models;

namespace DotNetCRUD.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
        {
            var employees = await _repo.GetAllAsync();
            return employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                Position = e.Position,
                Salary = e.Salary
            });
        }

        public async Task<EmployeeResponseDto?> GetByIdAsync(Guid id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null) return null;

            return new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary
            };
        }

        public async Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Position = dto.Position,
                Salary = dto.Salary
            };

            var addedEmployee = await _repo.AddAsync(employee);
            var response = new EmployeeResponseDto
            {
                Id = addedEmployee.Id,
                Name = addedEmployee.Name,
                Position = addedEmployee.Position,
                Salary = addedEmployee.Salary
            };
            return response;
        }

        public async Task<EmployeeResponseDto?> UpdateAsync(Guid id, EmployeeRequestDto dto)
        {
            var employee = new Employee
            {
                Id = id,
                Name = dto.Name,
                Position = dto.Position,
                Salary = dto.Salary
            };

            var updated = await _repo.UpdateAsync(employee);
            if (updated == null) return null;

            return new EmployeeResponseDto
            {
                Id = updated.Id,
                Name = updated.Name,
                Position = updated.Position,
                Salary = updated.Salary
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
