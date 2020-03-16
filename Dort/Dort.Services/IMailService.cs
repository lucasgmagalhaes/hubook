using Dort.Entity.HttpEntity;
using System.Threading.Tasks;

namespace Dort.Service
{
    public interface IMailService
    {
        Task SendAsync(string to, string content, string subject);
    }
}
