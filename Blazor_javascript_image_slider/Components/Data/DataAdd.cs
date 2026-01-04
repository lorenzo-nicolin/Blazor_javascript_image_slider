using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_javascript_image_slider.Components.Data
{
    public class DataAdd
    {
        private readonly string _connectionString;

        public DataAdd(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<List<string>> fetchData()
        {
            var result = new List<string>();
            using var conn = GetConnection();

            string sql = "SELECT * FROM [user_images_blob]";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    string name = reader.GetString(0);
                    result.Add(name);
                }
            }

            return result;
        }

        public async Task<List<Model.Customers>> GetCustomers()
        {
            List<Model.Customers> result = new List<Model.Customers>();
            using var conn = GetConnection();

            string sql = "SELECT * FROM [Customers]";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var customer = new Model.Customers
                    {

                        FirstName = reader["FirstName"]?.ToString(),
                        LastName = reader["LastName"]?.ToString()

                    };

                    result.Add(customer);

               
                }
            }



            return result;
        }


    }
}
