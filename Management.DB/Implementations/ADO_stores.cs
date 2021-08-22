using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;

namespace Management.DB
{
    public class ADO_stores : IDataStore
    {

        private static SqlConnection CreateConnection()
        {
            //declaring and assigning a connection string
            string ConnectionString = @"Data Source= .;Initial Catalog=WomenTechsters;Integrated Security=true";
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }

        //method to create a new store in the store table.
        public async Task<Store> AddStoreToDbAsync(Store _store)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                //creating a query
                string query = ("INSERT INTO Stores VALUES (StoreType = @storeType, StoreName = @storeName, StoreId = @storeId, Product = @product)");

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("StoreId", SqlDbType.NVarChar).Value = _store.StoreId;
                command.Parameters.Add("StoreType", SqlDbType.NVarChar).Value = _store.StoreType;
                command.Parameters.Add("StoreName", SqlDbType.NVarChar).Value = _store.StoreName;
                command.Parameters.Add("Product", SqlDbType.NVarChar).Value = _store.Product;
                command.Parameters.Add("UserId", SqlDbType.NVarChar).Value = _store.UserId;

                var rows = await command.ExecuteNonQueryAsync();

                await connection.CloseAsync();

                if (rows > 0)
                {
                    return _store;
                }
                return _store;
            }
        }

        //method to update the store.
        public async Task<bool> AddProductsToStoreAsync(string storeId, int product)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                string query = "UPDATE Stores SET Product = @Product WHERE Id = @storeId";

                SqlCommand command = new SqlCommand(query, connection);

                IDataParameter productValue, storeIdValue;

                productValue = new SqlParameter
                {
                    Value = product,
                    SqlDbType = SqlDbType.NVarChar
                };

                storeIdValue = new SqlParameter
                {
                    Value = storeId,
                    SqlDbType = SqlDbType.NVarChar
                };

                var @params = new IDataParameter[] { productValue, storeIdValue };
                command.Parameters.AddRange(@params);

                var rows = await command.ExecuteNonQueryAsync();

                return rows > 0;
            }
        }

        public async Task<ICollection<Store>> ReadFromDatabase()
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            //declaring the query
            string query = "SELECT * FROM Stores";

            SqlCommand command = new SqlCommand(query, connection);

            var reader = await command.ExecuteReaderAsync();

            //creating a list of stores
            List<Store> stores = new List<Store>();

            //looping through the reader to read the data in the DB
            while (reader.Read())
            {
                //Passing the key - the key is the name of the column in the database
                var store =  new Store
                {
                    StoreType = (StoreTypes.StoreType)Enum.Parse(typeof(StoreTypes.StoreType),reader["StoreType"].ToString()),
                    StoreName = reader["StoreName"].ToString(),
                    StoreId = reader["StoreId"].ToString(),
                    Product = Convert.ToInt32(reader["Product"])
                };

                stores.Add(store);
            }
           
            return stores;
        }

        public Task<bool> ReadStoreDataFromDBAsync(Store storeData)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertUsingStoredProcedures(StoreTypes.StoreType storeType, string storeName, string storeId, int product)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "INSERTINTOSTORES";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("storeType", SqlDbType.VarChar).Value = storeType;
            command.Parameters.Add("storeName", SqlDbType.VarChar).Value = storeName;
            command.Parameters.Add("storeId", SqlDbType.VarChar).Value = storeId;
            command.Parameters.Add("product", SqlDbType.Int).Value = product;

            var rows = await command.ExecuteNonQueryAsync();

            return rows > 0;
        }
        
        public Task<int> GetStoreProductCountAsync(string storeId)
        {
            throw new NotImplementedException();
        }

        //method to delete a store - sql command called using stored procedure
        public async Task<bool> DeleteStore(string storeId)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DeleteStore", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("StoreId", SqlDbType.NVarChar).Value = storeId;

                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }

        //method to remove product from store.
        public Task<List<Store>> RemoveProductsFromStoreAsync(string storeId, int product)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Store>> GetAllStoresBelongingToACustomer(string userId)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectStores", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                List<Store> stores = new List<Store>();

                var reader = command.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    var store = new Store
                    {
                        StoreType = (StoreTypes.StoreType)Enum.Parse(typeof(StoreTypes.StoreType),reader["StoreType"].ToString()),
                        StoreId = reader["StoreId"].ToString(),
                        StoreName = reader["StoreName"].ToString(),
                        Product = Convert.ToInt32(reader["Product"]),
                        UserId = reader["UserId"].ToString()
                    };

                    stores.Add(store);
                }

                return stores;
            }
        }

    }
}