using Dort.Entity;
using Dort.Repository.Db;
using Dort.Utils;
using Microsoft.Extensions.Configuration;
using Repository;

namespace Dort.RepositoryImpl.Database
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        private readonly string passwordKey;
        public UserRepository(IDbConnectionFactory dbConnectionFactory, IConfiguration config) : base(dbConnectionFactory)
        {
            passwordKey = config.GetSection("passwordKey")?.Value;
        }

        public User FindByEmailndPassword(string email, string password)
        {
            string passEncrypted = Cryptography.Encrypt(password, passwordKey);

            return base.QueryFirstOrDefault("SELECT * FROM user_app WHERE email = @email and password = @password", new { email, password = passEncrypted });
        }

        public override User Insert(User user)
        {
            user.Password = Cryptography.Encrypt(user.Password, passwordKey);
            return base.Insert(user);
        }
    }
}
