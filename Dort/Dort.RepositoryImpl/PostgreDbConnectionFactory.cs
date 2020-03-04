using Npgsql;
using System.Data;

namespace Repository
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
        public IDbConnection Connect()
        {
            var sqlConnection = new NpgsqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
