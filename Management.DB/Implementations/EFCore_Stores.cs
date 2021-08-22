using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Management.Models;

namespace Management.DB.Implementations
{
    public class EFCore_Stores : IDataStore
    {
        public async Task<Store> AddStoreToDbAsync(Store _store)
        {
            using (StoreMgtDBContext context = new StoreMgtDBContext())
            {
                await context.AddAsync(_store);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return _store;
                }
                return _store;
            }
        }

        public Task<bool> ReadStoreDataFromDBAsync(Store storeData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddProductsToStoreAsync(string storeId, int product)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetStoreProductCountAsync(string storeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStore(string storeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Store>> RemoveProductsFromStoreAsync(string storeId, int product)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Store>> GetAllStoresBelongingToACustomer(string userId)
        {
            throw new NotImplementedException();
        }
    }
}