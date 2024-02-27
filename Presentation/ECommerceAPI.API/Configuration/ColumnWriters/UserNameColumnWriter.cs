using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace ECommerceAPI.API.Configurations.ColumnWriters
{
    public class UsernameColumnWriter : ILogEventSink
    {
        private readonly string _connectionString;

        public UsernameColumnWriter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Properties.TryGetValue("user_name", out var userNameValue))
            {
                var userName = userNameValue.ToString();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("INSERT INTO Logs (UserName) VALUES (@UserName)", connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
