using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Dort.Repository.Db
{
    public interface IBaseRepository<T, IdType>
    {
        Task<T> FindById(IdType id);
        Task<IEnumerable<T>> Find(object criteria = null);
        Task<T> FindOne(object criteria = null);
        Task<IEnumerable<T>> FindAll();
        Task Delete(T entity);
        Task DeleteAll();
        Task<T> Insert(T entity);
        Task Update(T entity);
        Task<IEnumerable<T>> Query(string sql, CommandType type, object parameter = null);
        Task<T> QueryFirstOrDefault(string sql, object parameter = null);
    }
}
