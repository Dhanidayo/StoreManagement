using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Models;

namespace Management.DB
{
    public interface IDataStore
    {
        //methods to be implemented by datastore
        Task<Store> WriteStoreDataToDBAsync(Store _store);
        Task<Store> ReadStoreDataFromDBAsync(Store storeData);
        Task<bool> AddProductsToStoreAsync(string storeId, int product);
        Task<int> GetStoreProductCountAsync(string storeId);
        Task<bool> DeleteStores(string storeId);
        Task<List<Store>> RemoveProductsFromStoreAsync(string storeId, int product);
    }
}