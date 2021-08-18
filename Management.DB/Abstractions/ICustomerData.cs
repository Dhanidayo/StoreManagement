using System.Collections.Generic;
using Management.Models;
using System.Threading.Tasks;

namespace Management.DB
{
    public interface ICustomerData
    {
        //methods to be implemented by CustomerData
        List<Customer> customers { get; set; }
        Task<bool> WriteDataToFile();
        Task<bool> ReadDataFromFile();
    }
}