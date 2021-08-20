using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Management.Models;
using Management.Commons;

namespace Management.DB
{
    public class DataStore : IDataStore
    {
        //public List<Store> stores { get; set; } = new List<Store>();

        //declaring path to file
        public static string filePath = @"../StoreDetails.txt";
        
        //method to write store data to file
        public async Task<Store> WriteStoreDataToDBAsync(Store _store)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    StreamWriter sw = File.CreateText(filePath);
                    await sw.DisposeAsync();
                }
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    string storeInfo = $"{_store.StoreType}, {_store.StoreName}, {_store.StoreId}, {_store.Product}";
                    writer.WriteLine(storeInfo);
                }
                return _store;
            }
            catch (FileNotFoundException)
            {
                
                throw new Exception();
            }
        }

        //method to read store data to file
        public async Task<Store> ReadStoreDataFromDBAsync(Store storeData)
        {
           try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Store details file does not exist");
                }
                using (StreamReader reader = File.OpenText(filePath))
                {
                    var readStoreDetails = await reader.ReadToEndAsync();
                    //removing unwanted space
                    readStoreDetails = readStoreDetails.TrimEnd();

                    string[] StoreDetails  = readStoreDetails.Split(Environment.NewLine);
                    foreach (var storeDetail in StoreDetails)
                    {
                        if (storeDetail.Contains(storeData.StoreId))
                        {
                            var data = storeDetail.Split(',');
                            TableDisplay.PrintRow(data[0], data[1], data[2], data[3]);
                        }
                        
                        // Store store = new Store
                        // {
                        //     StoreType = (StoreType)Enum.Parse(typeof(StoreType),data[0]),
                        //     StoreName = data[1],
                        //     StoreId = data[2],
                        //     Product = Int32.Parse(data[3])
                        // };
                    }
                }
                return storeData;
            }
            catch (FileNotFoundException)
            {
                
                throw new FileNotFoundException();
            }
        }

        public Task<bool> AddProductsToStoreAsync(string storeId, int Product)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetStoreProductCountAsync(string storeId)
        {
            int productCount = 0;

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string readFileContent = await streamReader.ReadToEndAsync();
                readFileContent = readFileContent.TrimEnd();
                string[] storeDetailLines = readFileContent.Split(Environment.NewLine);

                foreach (var storeDetailLine in storeDetailLines)
                {
                    var item = storeDetailLine.Split(',');
                    productCount =  Convert.ToInt32(item[3]);
                }
                return productCount;
            }
        }

        public Task<bool> DeleteStores(string storeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Store>> RemoveProductsFromStoreAsync(string storeId, int product)
        {
            throw new NotImplementedException();
        }
    }
}           
            
