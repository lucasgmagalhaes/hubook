using Dort.Entity;
using System.Threading.Tasks;

namespace Dort.Service
{
    public interface IUserService
    {
        Task<User> Create(string name, string email, string password);
        Task UpdateProfile(string name, string password, string profileImg);
        Task<User> FindByEmailAndPassword(string email, string password);
    }
}
