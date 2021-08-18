using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Models;

namespace Management.DB
{
    public interface IDataStore
    {
        //methods to be implemented by datastore
        List<Store> stores { get; set; }
        Task<bool> WriteDataToFile();
        Task<bool> ReadDataFromFile();
    }
}