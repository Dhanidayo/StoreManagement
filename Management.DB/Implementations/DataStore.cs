using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Management.Models;
using Management;

namespace Management.DB
{
    public class DataStore : IDataStore
    {
        public List<Store> stores { get; set; } = new List<Store>();

        //declaring path to file
        public static string filePath = @"../StoreDetails.txt";
        
        //method to write store data to file
        public async Task<bool> WriteDataToFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using FileStream createFs = File.Create(filePath);
                await createFs.DisposeAsync();

                var openedFile = File.AppendText(filePath);
                foreach (var store in stores)
                {
                    openedFile.WriteLine($"{store.StoreType}, {store.StoreName}, {store.StoreId}, {store.Product}");
                }
                openedFile.Dispose();
            }
            catch (FileNotFoundException)
            {
                
                return false;
            }
            return true;
        }

        //method to read store data to file
        public async Task<bool> ReadDataFromFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using FileStream createFs = File.Create(filePath);
                    await createFs.DisposeAsync();
                }
                var openedFile = await File.ReadAllLinesAsync(filePath);
                foreach (var storeDetail in openedFile)
                {
                    var data = storeDetail.Split(',');
                    Store store = new Store
                    {
                        StoreType = (StoreType)Enum.Parse(typeof(StoreType),data[0]),
                        StoreName = data[1],
                        StoreId = data[2],
                        Product = Int32.Parse(data[3])
                    };
                    stores.Add(store);
                }
            }
            catch (FileNotFoundException)
            {     
                return false;
            }
            return true;
        }
    }
}