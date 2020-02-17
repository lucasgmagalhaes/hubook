using AspNetCore.Identity.Dapper;
using Npgsql;
using System.Data;

namespace Context
{
    /// <summary>
    /// Creates a new <see cref="SqlConnection"/> instance for connecting to Microsoft SQL Server.
    /// </summary>
    public class PostgreDbConnectionFactory : IDbConnectionFactory
    {
        /// <summary>
        /// The connection string to use for connecting to Microsoft SQL Server.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <inheritdoc/>
        public IDbConnection Create()
        {
            var sqlConnection = new NpgsqlConnection("User Id=postgres;Host=localhost;Port=5432;Database=Hubrary;Password=teste-123");
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
