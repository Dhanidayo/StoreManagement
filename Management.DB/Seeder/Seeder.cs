using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Models;
using Newtonsoft.Json;


namespace Management.DB
{
    public class Seeder
    {
        public async static Task Seed(StoreMgtDBContext context)
        {
            await context.Database.EnsureCreatedAsync();
            
            if (!context.Customers.Any())
            {
                string data = await File.ReadAllTextAsync(@"../Seeder/Customers.json");
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(data);

                await context.Customers.AddRangeAsync(customers);

                await context.SaveChangesAsync();
            }

            if (!context.Stores.Any())
            {
                string data = await File.ReadAllTextAsync(@"../Seeder/Stores.json");
                List<Store> stores = JsonConvert.DeserializeObject<List<Store>(data);

                await context.Stores.AddRangeAsync(stores);

                await context.SaveChangesAsync();
            }
        }
    }
}