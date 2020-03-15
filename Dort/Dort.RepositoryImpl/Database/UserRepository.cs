using Dort.Entity;
using Dort.Repository.Db;
using Repository;

namespace Dort.RepositoryImpl.Database
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        public UserRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }
    }
}
