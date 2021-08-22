using System;
using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class Products
    {
        public static string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public static string ProductName { get; set; }
        [Required]
        public static double Price { get; set; }

        //Navigational properties
        public Store Store { get; set; }
    }
}