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
        //customer actions method to read data from file
        private readonly ICustomerData _dataStore;
        public CustomerActions(ICustomerData dataStore)
        {
            _dataStore = dataStore;
            _dataStore.ReadDataFromFile();
        }

        //method to register a customer
        public Customer RegisterCustomer(string firstName, string lastName, string email, string passWord)
        {
            // if (!Validations.IsValidEmail(email))
            // {
            //     throw new FormatException("Email is not valid");
            // }
            Customer newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PassWord = passWord
            };
            //adding customer to file
            //var storage = _dataStore.customers.Add(newCustomer);
            //if (storage)
            //{
                return newCustomer;
            //}
            //throw new TimeoutException("Unable to create customer now, please try again later");
        }

        //method to login a customer - validate that the credentials are valid
        public Customer LoginCustomer(string email, string passWord)
        {
            //_dataStore.ReadDataFromFile();
            //var customerList = _dataStore.customers;
            //foreach (var customer in customerList)
            //{
                //check if credentials are valid and allow customer to login
                //if (customer.Email == email && customer.PassWord == passWord)
                //{
                    //return customer;
                //}
                //else
                //{
                    throw new ArgumentNullException();
                //}
            //}
            //return false;
        }
        public void SaveChanges()
        {
            _dataStore.WriteDataToFile();
        }
    }
}