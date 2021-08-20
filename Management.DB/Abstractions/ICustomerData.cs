using System.Collections.Generic;
using Management.Models;
using System.Threading.Tasks;

namespace Management.DB
{
    public interface ICustomerData
    {
        //methods to be implemented by CustomerData
        Task<Customer> WriteDataToFileAsync(Customer customer);
        Task<Customer> ReadDataFromFileAsync(string email, string passWord);
    }
}