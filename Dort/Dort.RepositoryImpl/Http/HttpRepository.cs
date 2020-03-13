using Dort.Enum;
using Dort.Repository.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dort.RepositoryImpl.Http
{
    public class HttpRepository : IHttpRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public HttpRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public HttpRepository(IHttpClientFactory clientFactory, Integration integration)
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(integration.Description());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string url)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        private HttpClient GetHttpClient()
        {
            return _client ?? new HttpClient();
        }
    }
}
