// using System;
// using Management.Models;
// using Management.DB;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace Management.BL
// {
//     public class SuperMarket : IStoreActions
//     {
//         List<int> productList = new List<int>();

//         private readonly IDataStore _dataStore;
//         public SuperMarket(IDataStore dataStore)
//         {
//             _dataStore = dataStore;
//             _dataStore.ReadDataFromFile();
//         }

//         public async Task<Store> CreateStoreAsync(StoreType storeType, string storeName, string userId, int product)
//         {
//             Store newStore = new Store
//             {
//                 StoreType = storeType,
//                 StoreName = storeName,
//                 UserId = userId,
//                 Product = product
//             };
//             //function to write store details to file.
//             var addNewStore = await _dataStore.WriteDataToFileAsync(newStore);
//             //check if create was successful, if not, throw an exception.
//             if (addNewStore)
//             {
//                 return newStore;
//             }
//             throw new TimeoutException("Unable to create store now, please try again later");
//         }

//         public int AddProducts(string storeId, int product)
//         {
//             return _customerData.c
//         }

//         public void RemoveProducts(int product)
//         {
//             productList.Remove(product);
//         }

//         public void SaveChanges()
//         {
//             _dataStore.WriteDataToFile();
//         }

//         public List<Store> GetStoreDetails()
//         {
//             return _dataStore.stores;
//         }
//     }
// }