using Dort.Entity.GoogleBook;
using Dort.Repository.GoogleBook;
using Dort.Repository.Http;
using Dort.RepositoryImpl.GoogleBook;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Dort.RepositoryImpl.GoogleBook
{
    public class GoogleBookRepository : IGoogleBookRepository
    {
        private readonly IHttpRepository _http;
        private const string _baseUrl = "https://www.googleapis.com/books/v1/volumes";
        public GoogleBookRepository(IHttpRepository http)
        {
            _http = http;
        }

        public async Task<SearchReponse> FindById(string id)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}/{id}");
        }

        public async Task<SearchReponse> FindByAuthor(string author)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={Parameters.Inauthor}:{author}");
        }

        public async Task<SearchReponse> FindByBookName(string book)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={book}");
        }

        public async Task<SearchReponse> FindBySubject(string category)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={Parameters.Subject}:{category}");
        }

        public async Task<SearchReponse> FindByFilter(IGoogleApiQueryBuilder filter)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={filter.BuildQueryString()}");
        }

        public async Task<SearchReponse> FindByPublisher(string publisher)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={Parameters.InPublisher}:{publisher}");
        }
    }
}
