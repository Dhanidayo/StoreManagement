using System.IO;
using System.Collections.Generic;
using Management.Models;
using System.Threading.Tasks;

namespace Management.DB
{
    public class CustomerData : ICustomerData
    {
        public List<Customer> customers { get; set; } = new List<Customer>();

        //declaring path to file
        public static string filePath = @"../CustomerDetails.txt";
        
        //method to write customers data to file
        public async Task<bool> WriteDataToFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using FileStream createFs = File.Create(filePath);
                await createFs.DisposeAsync();

                var openedFile = File.AppendText(filePath);
                foreach (var customer in customers)
                {
                    openedFile.WriteLine($"{customer.FirstName}, {customer.LastName}, {customer.Email}, {customer.Password}, {customer.Id}");
                }
                openedFile.Dispose();
            }
            catch (FileNotFoundException)
            {
                
                return false;
            }
            return true;
        }

        //method to read customers data from file
        public async Task<bool> ReadDataFromFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using FileStream createFs = File.Create(filePath);
                }
                var openedFile = await File.ReadAllLinesAsync(filePath);
                foreach (var customerDetail in openedFile)
                {
                    var data = customerDetail.Split(',');
                    Customer customer = new Customer
                    {
                        FirstName = data[0],
                        LastName = data[1],
                        Email = data[2],
                        Password = data[3],
                        Id = data[4]
                    };
                    customers.Add(customer);
                }
            }
            catch (FileNotFoundException)
            {
                
                return false;
            }
            return true;
        }
    }
}