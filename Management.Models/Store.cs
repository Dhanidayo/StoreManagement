using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Management.Commons;

namespace Management.Models
{
    //store model
    public class Store
    {
        private StoreTypes.StoreType storeType;
        public StoreTypes.StoreType StoreType
        {
            get { return storeType; }
            set { storeType = value; } //thinking of setting the value to StoreTypes.StoreType
        }
        
        [Required]
        private string storeName;
        public string StoreName
        {
            get { return storeName; }
            set { storeName = Validations.ValidateName(value); }
        }

        public string StoreId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string UserId { get; set; }

        private int product;
        public int Product
        {
            get { return product; }
            set { product = (value); }
        }

        //Navigational properties
        public Customer Customer { get; set; }
        public ICollection<Products> Products { get; set; } 
        
        
        
        
        // private int productCount;
        // public int ProductCount
        // {
        //     get { return productCount; }
        //     set { productCount = (value); }
        // }
    }
}