using Dort.Entity;
using Dort.Repository.Db;
using Dort.RepositoryImpl.Exceptions;
using Dort.Utils;
using Microsoft.Extensions.Configuration;
using Repository;
using System.Linq;

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
            var user = base.Find(new { email, password }).FirstOrDefault();
            
            if (user == null)
                throw new EntityNotFoundException($"User not found");
            
            return user;
        }

        public override User Insert(User user)
        {
            user.Password = Cryptography.Encrypt(user.Password, passwordKey);
            return base.Insert(user);
        }
    }
}
