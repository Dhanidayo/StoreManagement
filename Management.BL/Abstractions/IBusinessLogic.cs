using System;
using System.Threading.Tasks;
using Management.Models;
using System.Collections.Generic;

namespace Management.BL
{
    public interface IBusinessLogic
    {
        //method to be implemented by CustomerActions
        Customer RegisterCustomer(string customerId, string firstName, string lastName, string email, string passWord);
        Task<Customer> LoginCustomerAsync(string email, string passWord);
        bool SaveChanges();
    }
}