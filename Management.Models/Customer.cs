using System;
using Management.Commons;

namespace Management.Models
{   
    public class Customer
    {
        //customer model
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = Validations.ValidateName(value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = Validations.ValidateName(value); }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = Validations.IsValidEmail(value); }
        }
        
        private string password;
        public string Password
        {
            get { return password; }
            set { password = Validations.isValidPassword(value); }
        }
        

        //public string Email { get; set; }
        //public string PassWord { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}