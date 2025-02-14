using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;

namespace DotNetCRUD.IServices
{
    public interface IStudent_Services
    {

        Task<Student_ResponseDTO> AddStudent(Student_RequestDTO student);

        Task<Student_ResponseDTO> GetStudentById(int id);

        Task<IEnumerable<Student_ResponseDTO>> GetAllStudents();

        Task<Student_ResponseDTO> UpdateStudent(int id, Student_RequestDTO student);

        Task<bool> DeleteStudent(int id);
    }
}
