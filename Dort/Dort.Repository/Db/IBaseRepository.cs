using Dort.Entity;
using System.Collections.Generic;

namespace Dort.Repository.Db
{
    public interface IBaseRepository<T, IdType>
    {
        public T Find(object id);
        public IList<T> FindAll();
        public void Delete(T entity);
        public void DeleteAll();
        public T Insert(T entity);
        public void Update(T entity);
        IList<T> Query(string sql, object parameter = null);
        T QueryFirstOrDefault(string sql, object parameter = null);
    }
}
