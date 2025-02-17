using DotNetCRUD.Database;
using DotNetCRUD.IRepositories;
using DotNetCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Repositories
{
    public class StudentRepo : IStudent_Repo
    {
        private readonly ABCDbContext _dbContext;

        public StudentRepo(ABCDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<Student> AddStudent(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetByIdStudent(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student entity)
        {
            _dbContext.Students.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteStudent(int id) 
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
