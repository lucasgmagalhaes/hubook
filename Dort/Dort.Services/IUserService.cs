using Dort.Entity;
using System.Threading.Tasks;

namespace Dort.Service
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> FindByEmailAndPassword(string email, string password);
    }
}
