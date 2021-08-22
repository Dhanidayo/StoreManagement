using System;
using System.Text;
using Management.BL;
using Management.Commons;
using Management.Models;
using System.Threading.Tasks;

namespace StoreManagement.UI
{
    public class StoreDashboard
    {
        //IStoreActions.
        
        // private static string storeName;
        // private static string storeId;
        // private static StoreType storeType;
        // private static int product;


        /// Method responsible for displaying the user interface
         //method injection - taking two parameter.
        public static void DisplayStoreDashboard(IStoreActions storeActions, string cusId)
        {
            bool runStore = true;

            while (runStore)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Create a store.");

                Console.WriteLine("Enter: ");
                Console.WriteLine("1 to create a Kiosk");
                Console.WriteLine("2 to create a Supermarket");
                Console.WriteLine("3 to Add Products to store");
                Console.WriteLine("4 to Remove Products");
                Console.WriteLine("5 to get store details");
                Console.WriteLine("0 to go back to the main dashboard");

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
                                Console.WriteLine("Enter Kiosk name>>");
                                string storeName = Console.ReadLine();
                                storeName = Validations.ValidateName(storeName);

                                // Console.WriteLine("Enter Kiosk Id>>");
                                // string storeId = Console.ReadLine();
                                // storeId = Validations.ValidateName(storeId);

                                Console.WriteLine("Add a product");
                                int product = Convert.ToInt32(Console.ReadLine());
                                product = Validations.IsValidProduct(product);
                                if (product == -1)
                                {
                                    Console.WriteLine("Please enter a number");
                                    product = Validations.IsValidProduct(Convert.ToInt32(Console.ReadLine()));
                                }
                                product = Validations.IsValidProduct(product);

                                //assigning an id to the store
                                string storeId = Guid.NewGuid().ToString();

                                //create store with the input gotten from the user
                                Store store = storeActions.CreateKiosk(StoreTypes.StoreType.Kiosk, storeName, storeId, product).Result;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("${storeName} kiosk has been created successfuly!");
                                //ProductsDashboard.DisplayProductsDashboard(storeActions);
                                Console.ReadKey();
                                Console.Clear();
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
                                Console.WriteLine("Enter Supermarket name>>");
                                string storeName = Console.ReadLine();
                                storeName = Validations.ValidateName(storeName);

                                // Console.WriteLine("Enter Supermarket Id>>");
                                // string storeId = Console.ReadLine();
                                // storeId = Validations.ValidateName(storeId);

                                Console.WriteLine("Add a product");
                                int product = Convert.ToInt32(Console.ReadLine());
                                product = Validations.IsValidProduct(product);
                                // if (product == -1)
                                // {
                                //     Console.WriteLine("Please enter a number");
                                //     product = Validations.IsValidProduct(Convert.ToInt32(Console.ReadLine()));
                                // }
                                // product = Validations.IsValidProduct(product);

                                //assigning an id to the store
                                string storeId = cusId = Guid.NewGuid().ToString();

                                //create store with the input gotten from the user
                                Store store = storeActions.CreateSupermarket(StoreTypes.StoreType.Supermarket, storeName, storeId, product).Result;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("${storeName} supermarket has been created successfuly!");
                                ProductsDashboard.DisplayProductsDashboard(storeActions);
                                Console.ReadKey();
                                Console.Clear();
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
                            //going back to the main dashboard display
                            runStore = false;
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