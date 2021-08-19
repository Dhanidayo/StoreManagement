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
            ADO dataConnection  = new ADO();
            var result = dataConnection.InsertIntoCustomers().Result;
            
            try
            {
                ConfigureServices();
                IBusinessLogic actions_customer = serviceProvider.GetRequiredService<IBusinessLogic>();
                IStore actions_store = serviceProvider.GetRequiredService<IStore>();

                MainDashboard.DisplayDashboard(actions_store, actions_customer).Wait();
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
            services.AddScoped<IStore, Kiosk>();
            services.AddScoped<IStore, SuperMarket>();
            services.AddScoped<IDataStore, DataStore>();
            services.AddScoped<ICustomerData, CustomerData>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}