using System.Collections.Generic;

namespace Dort.Repository.Db
{
    public interface IBaseRepository<T, IdType>
    {
        T FindById(object id);
        IEnumerable<T> Find(object criteria = null);
        IList<T> FindAll();
        void Delete(T entity);
        void DeleteAll();
        T Insert(T entity);
        void Update(T entity);
        IList<T> Query(string sql, object parameter = null);
        T QueryFirstOrDefault(string sql, object parameter = null);
    }
}
