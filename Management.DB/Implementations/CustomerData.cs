using System;
using System.IO;
using System.Collections.Generic;
using Management.Models;
using System.Text;
using System.Threading.Tasks;

namespace Management.DB
{
    public class CustomerData : ICustomerData
    {
        //declaring path to file globally
        public static string filePath = @"../CustomerDetails.txt";
        
        //method to write customers' data to file
        public async Task<bool> AddCustomerToDBAsync(Customer customer)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    StreamWriter createSw = File.CreateText(filePath);
                    await createSw.DisposeAsync();
                }

                using (StreamWriter writer = File.AppendText(filePath))
                {
                    string customerFile =  $"{customer.FirstName}, {customer.LastName}, {customer.Email}, {customer.Password}, {customer.Id}";
                    writer.WriteLine(customerFile);
                    await writer.DisposeAsync();
                }
                //return customer;
            }
            catch (Exception)
            {
                
                return false;
            }
            return false;
        }

        //method to read customers data from file
        public async Task<Customer> GetCustomerFromDBAsync(string email, string passWord)
        {
            try
            {
                //check if the file exists. If it doesn't throw an exception,
                //else, read from file.
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Customer details file does not exist!");
                }
                using (StreamReader streamReadFile = File.OpenText(filePath))
                {
                    //read file content to the end
                    var readContent = await streamReadFile.ReadToEndAsync();
                    //remove unwanted spaces
                    readContent = readContent.TrimEnd();
                    string[] customerDetails  = readContent.Split(Environment.NewLine);

                    foreach (var customerDetail in customerDetails)
                    {
                        var data = customerDetail.Split(',');
                        if (data[2] == email && data[3] == passWord)
                        {
                            return new Customer
                            {
                                FirstName = data[0],
                                LastName = data[1],
                                Email = data[2],
                                Password = data[3],
                                Id = data[4]
                            };
                        }
                    }
                    
                }
            }
            catch (Exception)
            {
                
            }
            throw new UnauthorizedAccessException("Invalid Credentials");
        }
        
    }
}