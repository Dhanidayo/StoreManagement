using System;
using Management.Models;
using Management.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.BL
{
    public class Kiosk : IStore
    {
        List<int> productList = new List<int>();

        private readonly IDataStore _dataStore;
        public Kiosk(IDataStore dataStore)
        {
            _dataStore = dataStore;
            _dataStore.ReadDataFromFile();
        }
        public Store CreateStore(StoreType storeType, string storeName, string Id, int product)
        {
            Store newStore = new Store
            {
                StoreType = storeType,
                StoreName = storeName,
                Id = Id,
                Product = product
            };
            //function to add store details to file.
            //var storage =  _dataStore.stores.Add(newStore);
            //check if add was successful, if not, throw an exception.
            //if (storage)
            //{
                return newStore;
            //}
            //throw new TimeoutException("Unable to create store now, please try again later");
        }

        public int AddProducts(int product)
        {
            productList.Add(product);
            return product;
        }

        public void RemoveProducts(int product)
        {
            productList.Remove(product);
        }

        public void SaveChanges()
        {
            _dataStore.WriteDataToFile();
        }

        public List<Store> GetStoreDetails()
        {
            return _dataStore.stores;
        }
    }
}