using DotNetCRUD.Database;
using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.Models;
using DotNetCRUD.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ABCDbContext _dbContext;

        public SubjectRepository(ABCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            _dbContext.Subjects.AddAsync(subject);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _dbContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _dbContext.Subjects.FindAsync(id);
        }

        public async Task<Subject> UpdateSubjectByIdAsync(Subject subject)
        {
            _dbContext.Subjects.Update(subject);
            await _dbContext.SaveChangesAsync();
            return subject; 
        }



        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _dbContext.Subjects.FindAsync(id);
            if (subject == null) return false;

            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
