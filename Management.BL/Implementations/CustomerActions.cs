using System;
using System.Collections.Generic;
using Management.Commons;
using Management.Models;
using Management.DB;
using System.Threading.Tasks;
//using System.Web.ApplicationServices;

namespace Management.BL
{
    public class CustomerActions : IBusinessLogic
    {
        //Dependency Injection(Method Injection) - requesting for the service of ICustomerData
        //and using the read from file method to read customer's data from file.
        private readonly ICustomerData _customerData;
        public CustomerActions(ICustomerData customerData)
        {
            _customerData = customerData;
            _customerData.ReadDataFromFile();
        }

        //method to register a customer
        public Customer RegisterCustomer(string firstName, string lastName, string email, string passWord)
        {            
            Customer newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = passWord
            };
            //adding customer to file
            var storage = _customerData.WriteDataToFile(newCustomer);
            if (storage)
            {
                return newCustomer;
            }
            throw new TimeoutException("Unable to create customer now, please try again later");
        }

        //method to login a customer - validate that the credentials are valid
        public Customer LoginCustomer(string email, string passWord)
        {
            _customerData.ReadDataFromFile();
            var customerList = _customerData.customers;
            foreach (var customer in customerList)
            {
                //check if credentials are valid and allow customer to login
                if (customer.Email == email && customer.Password == passWord)
                {
                    return customer;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            return;
        }
        public void SaveChanges()
        {
            _customerData.WriteDataToFile();
        }
    }
}