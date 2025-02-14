using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;

namespace DotNetCRUD.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllAsync();
        Task<EmployeeResponseDto?> GetByIdAsync(Guid id);
        Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto);
        Task<EmployeeResponseDto?> UpdateAsync(Guid id, EmployeeRequestDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
