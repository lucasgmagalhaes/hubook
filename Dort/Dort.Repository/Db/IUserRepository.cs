using Dort.Entity;

namespace Dort.Repository.Db
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        User FindByEmailndPassword(string email, string password);
    }
}
