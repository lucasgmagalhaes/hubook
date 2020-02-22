using Dort.Entity.GoogleBook;

namespace Dort.Repository.GoogleBook
{
    public interface IGoogleBookRepository
    {
        /// <summary>
        /// Returns results where the text following this keyword is found in the title.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        SearchReponse SearchByBookName(string book);
        /// <summary>
        /// Returns results where the text following this keyword is found in the author.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        SearchReponse SearchByAuthor(string author);
        /// <summary>
        /// Returns results where the text following this keyword is found in the publisher.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        SearchReponse SearchByPublisher(string author);
        /// <summary>
        /// Returns results where the text following this keyword is listed in the category list of the volume.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        SearchReponse SearchByCategory(string category);
        SearchReponse SearchByFilter(QueryFilter filter);
    }
}
