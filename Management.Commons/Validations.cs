using System;
using System.Text.RegularExpressions;

namespace Management.Commons
{
    public class Validations
    {
        //method to validate email address format
        public static string IsValidEmail(string email)
        {
            try
            {
                while (!Regex.IsMatch(email, @"^[^@\s\.]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.WriteLine("Please enter a valid email e.g username@gmail.com");
                    email = Console.ReadLine();
                }
                return email;
            }
            catch (FormatException ex) //Catching errors relating to invalid format
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops, something is wrong!");
                throw new FormatException(ex.Message);

            }
            catch (Exception e)  //Catching all unforseen errors
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops, something is wrong!");
                throw new Exception(e.Message);
            }
        }

        //method to validate name and return first letter in uppercase
        public static string ValidateName(string name)
        {
            var firstChar = (int)name[0];
            if (!double.IsNaN(firstChar))
            {
                if (firstChar >= 65 && firstChar <= 91)
                {
                    return name;
                }
                else if(firstChar >= 97 && firstChar <= 122)
                {
                    return name.ToUpper()[0] + name.Substring(1);
                }
            }

            while (int.TryParse(name[0].ToString(), out int _))
            {
                name = name.Substring(1);
            }
            return ValidateName(name);
        }

        public static int IsValidInput(string data)
        {
            bool isValid = int.TryParse(data, out int value);
            if (!isValid)
            {
                return -1;
            }
            else if (value <= 0 || value > 5)
            {
                return -1;
            }
            else
            {
                return value;
            }
        }

        public static string isValidPassword(string passWord)
        {
            try
            {
                //passWord = " ";
                ConsoleKeyInfo key;
                do
                {
                key = Console.ReadKey(true);
                //statement to ensure that customer inputs an actual value and not use backspace or enter an empty value
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                passWord += key.KeyChar;
                Console.Write("*");
                }
                else
                {
                    passWord = passWord.Substring(0, (passWord.Length - 1));
                    Console.Write("\b \b");
                }
                if (!Regex.IsMatch(passWord, @"^[a-z]+@[^@#$%^&!]+$"))
                {
                    Console.WriteLine("Password must include letters and characters eg., password1234");
                    passWord = Console.ReadLine();
                }
                if (passWord.Length < 6)
                {
                    Console.WriteLine("Password cannot be less than six characters");
                    passWord = Console.ReadLine();
                }
                } while(key.Key != ConsoleKey.Enter); //to stop receiving keys once the enter button is pressed.
                {
                    Console.WriteLine();
                }
                return passWord;
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops, something is wrong!");
                throw new ArgumentException(ex.Message);
            }
            catch (Exception e)  //Catching all unforseen errors
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops, something is wrong!");
                throw new ArgumentException(e.Message);
            }
        }

        public static int IsValidProduct (int product)
        {
            try
            {
                if (product <= 100)
                {
                    Console.WriteLine("You need to have at least 100 products in your store, please add more products");
                    product = IsValidInput(Console.ReadLine());
                }
            return product;
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops, something is wrong!");
                throw new ArgumentException(ex.Message);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops, something is wrong!");
                throw new ArgumentException(e.Message);
            }
        }
    }
}