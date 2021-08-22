using System;
using Management.Models;
using Management.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.BL
{
    public class StoreActions : IStoreActions
    {
        //List<int> productList = new List<int>();

        private readonly IDataStore _dataStore;
        public StoreActions(IDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public async Task<Store> CreateKiosk(StoreTypes.StoreType storeType, string storeName, string userId, int product)
        {
            Store newStore = new Store
            {
                StoreType = storeType,
                StoreName = storeName,
                UserId = userId,
                Product = product
            };
            //function to write store details to file.
            var addNewStore = await _dataStore.AddStoreToDbAsync(newStore);
            //check if create was successful, if not, throw an exception.
            //if (addNewStore)
            //{
                return addNewStore;
            //}
            //throw new TimeoutException("Unable to create store now, please try again later");
        }

        public async Task<Store> CreateSupermarket(StoreTypes.StoreType storeType, string storeName, string userId, int product)
        {
            Store newStore = new Store
            {
                StoreType = storeType,
                StoreName = storeName,
                UserId = userId,
                Product = product
            };
            //function to write store details to file.
            var addNewStore = await _dataStore.AddStoreToDbAsync(newStore);
            //check if create was successful, if not, throw an exception.
            //if (addNewStore)
            //{
                return addNewStore;
            //}
            throw new TimeoutException("Unable to create store now, please try again later");
        }

        public async Task<bool> AddProducts(string storeId, int product)
        {
            return await _dataStore.AddProductsToStoreAsync(storeId, product);
        }

        public List<Store> GetStoreDetails(string storeId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Store>> GetAllCustomerStores(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStore(string storeId)
        {
            throw new NotImplementedException();
        }
    }
}