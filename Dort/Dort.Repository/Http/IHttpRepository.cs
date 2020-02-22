using System.Threading.Tasks;

namespace Dort.Repository.Http
{
    /// <summary>
    /// Define a set of methods that an http repository/client should implement.
    /// </summary>
    public interface IHttpRepository
    {
        /// <summary>
        /// Perform a GET request to a defined url.
        /// </summary>
        /// <typeparam name="T">Type of the return</typeparam>
        /// <param name="url">path of request</param>
        /// <returns>Content of request</returns>
        Task<T> GetAsync<T>(string url);
    }
}
