using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.IServices;
using DotNetCRUD.Models;
using DotNetCRUD.Repositories;

namespace DotNetCRUD.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository  ;
        }


        public async Task<Customer> AddCustomer(CustomerReqDTO customerReq)
        {
            var customer = new Customer
            {
               CustomerName = customerReq.CustomerName,
               Age = customerReq.Age,
               Address = customerReq.Address,
               PhoneNumber = customerReq.PhoneNumber,
               EmailAddress = customerReq.EmailAddress,

            };
            var data = await _customerRepository.AddCustomer(customer);
            return data;


        }

        public async Task<ICollection<Customer>> GetAllCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }

        public async Task<Customer>GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<CustomerResDTO> UpdateCustomer(CustomerReqDTO customerReqDTO , int id)
        {
            var getCustomer = await _customerRepository.GetCustomer(id);

            getCustomer.CustomerName = customerReqDTO.CustomerName;
            getCustomer.Address = customerReqDTO.Address;
            getCustomer.PhoneNumber = customerReqDTO.PhoneNumber;
            getCustomer.EmailAddress = customerReqDTO.EmailAddress;
            getCustomer.Age = customerReqDTO.Age;


            var check = await _customerRepository.EditCustomer(getCustomer);

            var res = new CustomerResDTO
            {
                CustomerId = id,
                CustomerName = check.CustomerName,
                Address = check.Address,
                PhoneNumber = check.PhoneNumber,
                EmailAddress = check.EmailAddress,
                Age= check.Age,

            };

            return res;

        }


        public async Task<Customer> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id); 
        }


    }
}
