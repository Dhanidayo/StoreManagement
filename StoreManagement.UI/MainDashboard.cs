using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.BL;
using Management.Commons;
using Management.Models;

namespace StoreManagement.UI
{
    public class MainDashboard
    {
        private static string firstName;
        private static string lastName;
        private static string email_Address;
        private static string passWord;


        /// Method responsible for displaying the user interface
        //method injection - taking two parameters
        public static async Task DisplayDashboard(IStore actions_store, IBusinessLogic actions_customer)
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
                                string firstName = Console.ReadLine();
                                firstName = Validations.ValidateName(firstName);

                                Console.WriteLine("Enter LastName: ");
                                string lastName = Console.ReadLine();
                                lastName = Validations.ValidateName(lastName);

                                Console.WriteLine("Enter Email Address: ");
                                string email_Address = Console.ReadLine();
                                email_Address = Validations.IsValidEmail(email_Address);

                                Console.WriteLine("Enter Password: ");
                                string passWord = Console.ReadLine();
                                passWord = Validations.isValidPassword(passWord);
                                
                                //change the foreground color of the console to green
                                //the register customer method executes
                                //customer details inputs are written to file.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Customer customer =  actions_customer.RegisterCustomer(firstName, lastName, email_Address, passWord);
                                actions_customer.SaveChanges();
                                Console.WriteLine("Email: "+ email_Address);
                                Console.WriteLine("Password: " + passWord);
                                Console.WriteLine($"Customer \"{customer.FullName}\" has been added successfully");
                                //display store dashboard
                                await StoreDashboard.DisplayStoreDashboard(actions_store, actions_customer);
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
                                Console.WriteLine("Please enter your email address:");
                                string email_Address = Console.ReadLine();
                                email_Address = Validations.IsValidEmail(email_Address);

                                Console.WriteLine("Please enter your password:");
                                string passWord = Console.ReadLine();
                                passWord = Validations.isValidPassword(passWord);

                                var loginCustomer = actions_customer.LoginCustomer(email_Address, passWord);

                                //if login matches with registered user, display store dashboard. If not, show error message.
                                //if (loginCustomer == 1)
                                //{
                                    Console.WriteLine("Login Successful");
                                    await StoreDashboard.DisplayStoreDashboard(actions_store, actions_customer);
                                //}
                                // else
                                // {
                                //     Console.WriteLine("Invalid login credentials");
                                // }
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












//Console.ForegroundColor = ConsoleColor.Green;


                                //Console.WriteLine(Validations.IsValidEmail(email));
                                // if (!IsValidEmail(email))
                                // {
                                //     Console.WriteLine("Email does not exist, please register");
                                //     Console.clear();
                                // }
                                // else if (email != userEmail || passWord != userPassword) //yet to implement userEmail & userPassword. Should be
                                // {                                                        //data saved in the file.
                                //     Console.WriteLine("Invalid email or password. Please check that you are typing the correct email or password");
                                    
                                // }