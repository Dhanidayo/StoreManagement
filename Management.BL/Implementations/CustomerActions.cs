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
            _customerData = customerData ?? throw new ArgumentNullException(nameof(customerData));
        }

        //method to register a customer
        public Customer RegisterCustomer(string customerId, string firstName, string lastName, string email, string passWord)
        {            
            Customer newCustomer = new Customer
            {
                Id = customerId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = passWord
            };
            //adding customer to file
            var storage = _customerData.WriteDataToFileAsync(newCustomer);
            //if (storage)
                return newCustomer;
            //throw new TimeoutException("Unable to create customer now, please try again later");
        }

        //method to login a customer - validate that the credentials are valid
        public async Task<Customer> LoginCustomerAsync(string email, string passWord)
        {
            Customer isLoggedIn = new Customer
            {
                Email = email,
                Password = passWord
            };
            var existingCustomer = await _customerData.ReadDataFromFileAsync(email, passWord);
            if (existingCustomer == null)
            {
                throw new ArgumentNullException("Customer does not exist");
            }
            return existingCustomer;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}















//LOGIN LOGIC
// _customerData.ReadDataFromFile();
//             Customer customerList = _customerData.customerList;
//             foreach (var customer in customerList)
//             {
//                 //check if credentials are valid and allow customer to login
//                 if (customer.Email == email && customer.Password == passWord)
//                 {
//                     return customer;
//                 }
//                 else
//                 {
//                     throw new ArgumentNullException();
//                 }
//             }
//             return customerList;