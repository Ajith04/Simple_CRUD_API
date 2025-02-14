using DotNetCRUD.Database;
using DotNetCRUD.IRepositories;
using DotNetCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ABCDbContext _context;

        public EmployeeRepository(ABCDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            var existing = await _context.Employees.FindAsync(employee.Id);
            if (existing == null) return null;

            existing.Name = employee.Name;
            existing.Position = employee.Position;
            existing.Salary = employee.Salary;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
