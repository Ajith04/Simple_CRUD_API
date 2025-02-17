using DotNetCRUD.Models;
using DotNetCRUD.Repositories;

namespace DotNetCRUD.IRepositories
{
    public interface IStudent_Repo
    {

        Task<Student> AddStudent(Student student);

        Task<Student> GetByIdStudent(int id);

        Task<IEnumerable<Student>> GetAllStudent();

        Task<Student> UpdateStudent(Student entity);

        Task<bool> DeleteStudent(int id);




    }
}
