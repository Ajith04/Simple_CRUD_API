using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;

namespace DotNetCRUD.IServices
{
    public interface ISubjectService
    {
        Task<SubjectResponseDTO> AddSubjectAsync(SubjectRequestDTO subjectRequestDTO);
        Task<IEnumerable<SubjectResponseDTO>> GetAllSubjectsAsync();
        Task<SubjectResponseDTO> GetSubjectByIdAsync(int id);
        Task<SubjectResponseDTO> UpdateSubjectByIdAsync(int id, SubjectRequestDTO subjectRequestDTO);
        Task DeleteSubjectAsync(int id);
    }
}
