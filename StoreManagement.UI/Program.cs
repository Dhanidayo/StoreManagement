using System;
using Management.BL;
using Microsoft.Extensions.DependencyInjection;
using Management.DB;


namespace StoreManagement.UI
{
    class Program
    {
        //method to handle dependency injections.
        //registration of the dependency in a service container
        private static IServiceProvider serviceProvider;
        
        static void Main(string[] args)
        {
            //ADO dataConnection  = new ADO();
            //var result = dataConnection.InsertIntoCustomers().Result;

            ConfigureServices();
            IBusinessLogic customerActions = serviceProvider.GetRequiredService<IBusinessLogic>();
            IStoreActions storeActions = serviceProvider.GetRequiredService<IStoreActions>();
            try
            {
                MainDashboard.DisplayDashboard(customerActions, storeActions).Wait();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to start application");
            }
        }

        //registration of services into the configure services method.
        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddScoped<IBusinessLogic, CustomerActions>();
            services.AddScoped<IStoreActions, StoreActions>();
            services.AddScoped<IDataStore, DataStore>();
            services.AddScoped<ICustomerData, CustomerData>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}