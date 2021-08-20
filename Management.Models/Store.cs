using System;
using Management.Commons;

namespace Management.Models
{
    //store model
    public class Store
    {
        private StoreType storeType;
        public StoreType StoreType
        {
            get { return storeType; }
            set { storeType = value; }
        }
        
        private string storeName;
        public string StoreName
        {
            get { return storeName; }
            set { storeName = Validations.ValidateName(value); }
        }

        public string StoreId { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }

        private int product;
        public int Product
        {
            get { return product; }
            set { product = (value); }
        }

        // private int productCount;
        // public int ProductCount
        // {
        //     get { return productCount; }
        //     set { productCount = (value); }
        // }
    }
}