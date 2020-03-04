using Dort.Entity.GoogleBook;
using Dort.Repository.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Dort.Repository.GoogleBook
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
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q=inauthor:{author}");
        }

        public async Task<SearchReponse> FindByBookName(string book)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={book}");
        }

        public async Task<SearchReponse> FindByCategory(string category)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q=subject:{category}");
        }

        public async Task<SearchReponse> FindByFilter(QueryFilter filter)
        {
            if (filter == null)
            {
                return await _http.GetAsync<SearchReponse>($"{_baseUrl}");
            }

            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Author))
            {
                builder.Append(filter.Author);
            }

            if (!string.IsNullOrEmpty(filter.Publisher))
            {
                if (!string.IsNullOrEmpty(builder.ToString()))
                {
                    builder.Append("+");
                }

                builder.Append($"inauthor:{filter.Author}");
            }

            if (!string.IsNullOrEmpty(filter.Publisher))
            {
                if (!string.IsNullOrEmpty(builder.ToString()))
                {
                    builder.Append("+");
                }

                builder.Append($"publisher:{filter.Publisher}");
            }

            if (!string.IsNullOrEmpty(filter.Subject))
            {
                if (!string.IsNullOrEmpty(builder.ToString()))
                {
                    builder.Append("+");
                }

                builder.Append($"subject:{filter.Subject}");
            }

            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q={builder.ToString()}");

            throw new NotImplementedException();
        }

        public async Task<SearchReponse> FindByPublisher(string publisher)
        {
            return await _http.GetAsync<SearchReponse>($"{_baseUrl}?q=inpublisher:{publisher}");
        }
    }
}
