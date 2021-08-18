using System;
using Management.BL;
using Management.Models;
using Management.Commons;
using System.Threading.Tasks;

namespace StoreManagement.UI
{
    public class ProductsDashboard
    {
          private static int product;
        
        //method to display products on dashboard
        public static void DisplayProductsDashboard(IStore actions_store)
        {
            Console.WriteLine("Press:");
            Console.WriteLine("1 to Add products");
            Console.WriteLine("2 to remove product");
            Console.WriteLine("3 get store details");

            var customerInput = Validations.IsValidInput(Console.ReadLine());
            if (customerInput == -1)
            {
                Console.WriteLine("Please enter a valid input");
                Console.Clear();
            }
            else
            {
                switch (customerInput)
                {
                    case 1:
                        try
                        {                
                            Console.WriteLine("Add a product");
                            var productInput = Validations.IsValidInput(Console.ReadLine());
                            if (productInput == -1)
                            {
                                Console.WriteLine("Please enter a number");
                                productInput  = Validations.IsValidProduct(Convert.ToInt32(Console.ReadLine()));
                            }
                            product = Validations.IsValidProduct(productInput);


                            //save store credentials to file
                            actions_store.AddProducts(product);
                            actions_store.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.ReadKey();
                        }
                        catch(FormatException ex)
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
                    case 2:
                        try
                        {
                            Console.WriteLine("Enter the product you want to remove");
                            var productInput = Validations.IsValidInput(Console.ReadLine());
                            if (productInput == -1)
                            {
                                Console.WriteLine("Please enter a number");
                                productInput = Validations.IsValidProduct(Convert.ToInt32(Console.ReadLine()));
                            }
                            product = Validations.IsValidProduct(productInput);

                            actions_store.RemoveProducts(product);
                            actions_store.SaveChanges();
                        }
                        catch(FormatException ex)
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
                    case 0:
                        try
                        {
                            Console.WriteLine("===========STORE DETAILS===========");
                            var myStore = actions_store.GetStoreDetails();
                            //await UIHelpers.DisplayHistoryTable(stores);
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
                    default:
                        Console.Clear();
                        break;
                }        
            }          
        }
    }
}