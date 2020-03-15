using Dort.Entity;
using System.Threading.Tasks;

namespace Dort.Service
{
    public interface IUserService
    {
        Task<User> Create(string name, string email, string password);
        Task<User> FindByEmailAndPassword(string email, string password);
    }
}
