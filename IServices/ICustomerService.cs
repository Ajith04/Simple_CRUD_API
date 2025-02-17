using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.Models;

namespace DotNetCRUD.IServices
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(CustomerReqDTO customerReq);
        Task<ICollection<Customer>> GetAllCustomer();
        Task<CustomerResDTO> UpdateCustomer(CustomerReqDTO customerReqDTO, int id);
        Task<Customer> DeleteCustomer(int id);
        Task<Customer> GetCustomer(int id);

    }
}
