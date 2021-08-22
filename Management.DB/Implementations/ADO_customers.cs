using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;

namespace Management.DB
{
    public class ADO_customers
    {
        private static SqlConnection CreateConnection()
        {
            //declaring and assigning a connection string
            string ConnectionString = @"Data Source= .;Initial Catalog=WomenTechsters;Integrated Security=true";
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }

        public async Task<Customer> AddCustomerToDBAsync(Customer customer)
        {
            using(var connection = CreateConnection())
            {
                connection.Open();

                //creating a query
                string query = ("INSERT INTO Customers VALUES (FirstName = @firstName, LastName = @lastName, Email = @email, Passsword = @passWord, Id = @id)");

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = customer.FirstName;
                command.Parameters.Add("LastName", SqlDbType.NVarChar).Value = customer.LastName;
                command.Parameters.Add("Email", SqlDbType.NVarChar).Value = customer.Email;
                command.Parameters.Add("Password", SqlDbType.NVarChar).Value = customer.Password;
                command.Parameters.Add("Id", SqlDbType.NVarChar).Value = customer.Id;


                var rows = await command.ExecuteNonQueryAsync();

                await connection.CloseAsync();

                if (rows > 0)
                {
                    return customer;
                }
                return customer;
            }
        }

        public async Task<Customer> GetCustomerFromDBAsync(string email, string passWord)
        {
           try
           {
                Customer loginCustomer = new Customer();

                using(var connection = CreateConnection())
                {
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand("LoginACustomer", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add("email", SqlDbType.VarChar).Value = email;
                    command.Parameters.Add("passWord", SqlDbType.VarChar).Value = passWord;

                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            loginCustomer = new Customer
                            {
                                Id = reader["Id"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString()
                            };

                            await connection.CloseAsync();
                        }
                        return loginCustomer;
                    }
                }
           }
           catch (System.Exception)
           {    
               
           }
           throw new UnauthorizedAccessException("Invalid Credentials");
        }

        public async Task<bool> UpdateCustomers(string firstName, string email, int id)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "UPDATE Customers SET FirstName = @FirstName, Email = @Email WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("FirstName", SqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("Email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("Id", SqlDbType.Int).Value = id;

            var rows = await command.ExecuteNonQueryAsync();

            return rows > 0;
        }

        public async Task<List<Customer>> ReadFromDatabase()
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            //declaring the query.
            string query = "SELECT * FROM Customers";

            SqlCommand command = new SqlCommand(query, connection);

            var reader = await command.ExecuteReaderAsync();

            //creating a list of customers
            List<Customer> customers = new List<Customer>();

            //looping through the reader to read the data in the DB
            while (reader.Read())
            {
                //Passing the key - the key is the name of the column in the database
                var customer =  new Customer
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString(),
                    Id = reader["Id"].ToString()
                };

                customers.Add(customer);
            }
           
            return customers;
        }

        public async Task<bool> InsertUsingStoredProcedures(string firstName, string lastName, string email, string passWord)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "INSERTINTOCUSTOMERS";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("lastName", SqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("firstName", SqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("passWord", SqlDbType.VarChar).Value = passWord;

            var rows = await command.ExecuteNonQueryAsync();

            return rows > 0;
        }
    }
}