using System;
using Management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.BL
{
    public interface IStore
    {
        //methods to be implemented by Kiosk and Supermarket
        Store CreateStore(StoreType storeType, string storeName, string storeId, int product);
        int AddProducts(int product);
        void RemoveProducts(int product);
        //void PrintTotalNumberofProducts();
        List<Store> GetStoreDetails();
        void SaveChanges();
    }
}