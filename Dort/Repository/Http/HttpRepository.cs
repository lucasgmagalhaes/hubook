using System.Net.Http;

namespace Dort.RepositoryImpl.Http
{
    public class HttpRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
