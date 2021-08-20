using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.BL;
using Management.Commons;
using Management.Models;
using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement.UI
{
    public class MainDashboard
    {       
        private static string firstName;
        private static string lastName;
        private static string email_Address;
        private static string passWord;
        private static string cusId;


        /// Method for displaying the user interface
        //method injection - taking two parameters
        public static void DisplayDashboard(IBusinessLogic customerActions)
        {
            bool runApp = true;

            while (runApp)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Welcome to Store Manager App.");

                Console.WriteLine("Enter: ");
                Console.WriteLine("1 to Register");
                Console.WriteLine("2 to Login");
                Console.WriteLine("3 to Logout");

                var input = Validations.IsValidInput(Console.ReadLine());
                if (input == -1)
                {
                    Console.WriteLine("Please enter a valid input");
                    Console.Clear();
                }
                else
                {
                    switch (input)
                    {
                        case 1:
                            //Handling all errors in the UI for accurate stack trace.
                            try
                            {
                                Console.WriteLine("Enter FirstName: ");
                                firstName = Console.ReadLine();

                                Console.WriteLine("Enter LastName: ");
                                lastName = Console.ReadLine();

                                Console.WriteLine("Enter Email Address: ");
                                email_Address = Console.ReadLine();
                               
                                Console.WriteLine("Enter Password: ");
                                passWord = Console.ReadLine();
                                
                                //change the foreground color of the console to green
                                //the register customer method executes
                                //customer details inputs are written to file.
                                Console.ForegroundColor = ConsoleColor.Green;

                                cusId = Guid.NewGuid().ToString();
                                Customer customer = customerActions.RegisterCustomer(cusId, firstName, lastName, email_Address, passWord);
                                //customerActions.SaveChanges();
                                Console.WriteLine("Email: "+ email_Address);
                                Console.WriteLine("Password: " + passWord);
                                Console.WriteLine($"Customer \"{customer.FullName}\" has been added successfully");
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch(FormatException ex) //Catching invalid format errors
                            {        
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception e)  //Catching all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Please enter your login details.");
                                Console.WriteLine("Email address:");
                                email_Address = Console.ReadLine();

                                Console.WriteLine("Password:");
                                passWord = Console.ReadLine();
                                
                                var loginCustomer = customerActions.LoginCustomerAsync(email_Address, passWord);

                                Console.WriteLine("Login Successful");
                                Program.ConfigureServices();
                                IStoreActions storeActions = Program.serviceProvider.GetRequiredService<IStoreActions>();
                                //display store dashboard
                                StoreDashboard.DisplayStoreDashboard(storeActions, cusId);
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (FormatException ex)
                            { 
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;   
                        case 3:
                            Console.WriteLine("Exiting App...");
                            runApp = false;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }        
                }
            }         
        }
    }   
}



