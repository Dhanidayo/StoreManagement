using System.Collections.Generic;
using Management.Models;
using System.Threading.Tasks;

namespace Management.DB
{
    public interface ICustomerData
    {
        //methods to be implemented by CustomerData
        Task<Customer> AddCustomerToDBAsync(Customer customer);
        Task<Customer> GetCustomerFromDBAsync(string email, string passWord);
    }
}