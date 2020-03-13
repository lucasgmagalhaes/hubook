using Dort.Entity.GoogleBook;
using System.Threading.Tasks;

namespace Dort.Repository.GoogleBook
{
    public interface IGoogleBookRepository
    {
        /// <summary>
        /// Returns results where the text following this keyword is found in the title.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<SearchReponse> FindByBookName(string book);
        /// <summary>
        /// Returns results where the text following this keyword is found in the author.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        Task<SearchReponse> FindByAuthor(string author);
        /// <summary>
        /// Returns results where the text following this keyword is found in the publisher.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        Task<SearchReponse> FindByPublisher(string publisher);
        /// <summary>
        /// Returns results where the text following this keyword is listed in the category list of the volume.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        Task<SearchReponse> FindBySubject(string category);

        Task<SearchReponse> FindByFilter(IGoogleApiQueryBuilder filter);
    }
}
