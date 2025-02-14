using DotNetCRUD.Models;

namespace DotNetCRUD.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<ICollection<Customer>> GetAllCustomer();
        Task<Customer> EditCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
