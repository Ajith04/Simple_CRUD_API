using DotNetCRUD.Database;
using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.Models;
using DotNetCRUD.Repositories;

namespace DotNetCRUD.IRepositories
{
    public interface ISubjectRepository 
    {
        Task AddSubjectAsync(Subject subject);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<Subject> UpdateSubjectByIdAsync(Subject subject);
        Task<bool> DeleteSubjectAsync(int id);
    }
}
