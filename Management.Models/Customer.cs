using System;
using Management.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Management.Models
{   
    public class Customer
    {
        //customer model
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        private string firstName;
        [Required]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = Validations.ValidateName(value); }
        }

        private string lastName;
        [Required]
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
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address is invalid")]
        public string Email
        {
            get { return email; }
            set { email = Validations.IsValidEmail(value); }
        }
        
        private string password;
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password
        {
            get { return password; }
            set { password = Validations.isValidPassword(value); }
        }

        //Navigational property
        //Property of a customer having many stores.
        public ICollection<Store> stores { get; set; }
    }
}