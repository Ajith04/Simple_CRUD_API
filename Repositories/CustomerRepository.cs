using System.Collections.ObjectModel;
using DotNetCRUD.Database;
using DotNetCRUD.IRepositories;
using DotNetCRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ABCDbContext _ABCDbContext;

        public CustomerRepository(ABCDbContext aBCDbContext)
        {
            _ABCDbContext = aBCDbContext;
        }


        public async Task<Customer> AddCustomer(Customer customer)
        {
            var data = await _ABCDbContext.Customers.AddAsync(customer);
            await _ABCDbContext.SaveChangesAsync();

            return data.Entity;

        }


        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _ABCDbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception();
            }

            return customer;
        }


        public async Task<ICollection<Customer>> GetAllCustomer()
        {
            return await _ABCDbContext.Customers.ToListAsync();
        }



        public async Task<Customer> EditCustomer(Customer customer)
        {
            var editedCustomer = _ABCDbContext.Customers.Update(customer);
            await _ABCDbContext.SaveChangesAsync();
            return editedCustomer.Entity;

        }

        public async Task<Customer>DeleteCustomer (int id)
        {
            var customer = await _ABCDbContext.Customers.FindAsync (id);
            if (customer == null)
            {
                throw new Exception();
            }

            _ABCDbContext.Customers.Remove(customer);
            await _ABCDbContext.SaveChangesAsync();

            return customer;
            
        }

    }
}
