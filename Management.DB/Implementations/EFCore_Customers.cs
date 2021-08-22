using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Management.Models;

namespace Management.DB
{
    public class EFCore_Customers : ICustomerData
    {
        public async Task<Customer> AddCustomerToDBAsync(Customer customer)
        {
            using (StoreMgtDBContext context = new StoreMgtDBContext())
            {
                await context.AddAsync(customer);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return customer;
                }
                return customer;
            }
        }

        public async Task<Customer> GetCustomerFromDBAsync(string email, string passWord)
        {
            using (StoreMgtDBContext context = new StoreMgtDBContext())
            {
                Customer customer = await context.Customers
                    .Include(customer => customer.stores)
                    .FirstOrDefaultAsync(customer => customer.Email == email && customer.Password == passWord);

                return customer;
            }
        }

        //method to update a customer's info
        //In this case, updating the fitstname
        public bool Update(string Id, string firstname)
        {
            using (StoreMgtDBContext context = new StoreMgtDBContext())
            {
                Customer customer = context.Customers.FirstOrDefault(customer => customer.Id == Id);

                customer.FirstName = firstname;

                context.Update(customer);

                var result = context.SaveChanges();

                return result > 0;
            }
        }

        //method to delete a customer's info
        public bool Delete(string Id)
        {
            using (StoreMgtDBContext context = new StoreMgtDBContext())
            {
                Customer customer = context.Customers.FirstOrDefault(customer => customer.Id == Id);

                context.Remove(customer);

                var result = context.SaveChanges();

                return result > 0;
            }

        }
    }
}