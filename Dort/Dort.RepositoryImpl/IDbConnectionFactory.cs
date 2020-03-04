using System.Data;

namespace Repository
{
    public interface IDbConnectionFactory
    {
        string ConnectionString { get; set; }
        IDbConnection Connect();
    }
}
