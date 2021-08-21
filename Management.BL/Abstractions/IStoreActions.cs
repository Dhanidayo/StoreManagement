using System;
using Management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace Management.BL
{
    public interface IStoreActions
    {
        //methods to be implemented by Kiosk and Supermarket
        Task<Store> CreateKiosk(StoreTypes.StoreType storeType, string storeName, string userId, int product);
        Task<Store> CreateSupermarket(StoreTypes.StoreType storeType, string storeName, string userId, int product);
        Task<bool> AddProducts(string storeId, int product);
        List<Store> GetStoreDetails(string storeId, string userId);
        Task<ICollection<Store>> GetAllCustomerStores(string userId);
        Task<bool> DeleteStore(string storeId);
    }
}