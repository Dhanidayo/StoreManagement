using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;

namespace Management.DB
{
    public class ADO_stores
    {
        //declaring and assigning a connection string
        private const string ConnectionString = @"Data Source= .;Initial Catalog=WomenTechsters;Integrated Security=true;";


        public async Task<bool> InsertIntoStores(string storeType, string storeName, string storeId, string product)
        {
            //creating the connection object with connection the string.
            var connection = CreateConnection();
            await connection.OpenAsync();

            //creating a query
            string query = $"INSERT INTO Stores VALUES ('{storeType}', '{storeName}', '{storeId}', '{product}')";

            SqlCommand command = new SqlCommand(query, connection);

            var rows = await command.ExecuteNonQueryAsync();

            await connection.CloseAsync();

            return rows > 0;
        }

        public async Task<bool> UpdateStores(string storeName, int product, int id)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "UPDATE Stores SET StoreName = @StoreName, Product = @Product WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("StoreName", SqlDbType.VarChar).Value = storeName;
            command.Parameters.Add("Product", SqlDbType.Int).Value = product;
            command.Parameters.Add("Id", SqlDbType.Int).Value = id;

            var rows = await command.ExecuteNonQueryAsync();

            return rows > 0;
        }

        public async Task<List<Store>> ReadFromDatabase()
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
                    StoreType = (StoreType)Enum.Parse(typeof(StoreType),reader["StoreType"].ToString()),
                    StoreName = reader["StoreName"].ToString(),
                    Id = reader["Id"].ToString(),
                    Product = Convert.ToInt32(reader["Product"])
                };

                stores.Add(store);
            }
           
            return stores;
        }

        public async Task<bool> InsertUsingStoredProcedures(string storeType, string storeName, string storeId, int product)
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

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}