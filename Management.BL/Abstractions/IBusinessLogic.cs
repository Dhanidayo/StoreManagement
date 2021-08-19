using System;
using System.Threading.Tasks;
using Management.Models;
using System.Collections.Generic;

namespace Management.BL
{
    public interface IBusinessLogic
    {
        //method to be implemented by CustomerActions
        Customer RegisterCustomer(string firstName, string lastName, string email, string passWord);
        Customer LoginCustomer(string email, string passWord);
        void SaveChanges();

        //List<Customer> RegisterCustomer(string firstName, string lastName, string email, string passWord);
    }
}