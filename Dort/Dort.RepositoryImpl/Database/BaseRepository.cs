using Dapper;
using Dapper.Contrib.Extensions;
using Dort.Entity;
using Dort.Entity.Attributes;
using Dort.Repository.Db;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dort.RepositoryImpl.Database
{
    public abstract class BaseRepository<T, IdType> : IBaseRepository<T, IdType> where T : class, IBaseEntity<IdType>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<T> FindById(IdType id)
        {
            using IDbConnection conn = _dbConnectionFactory.Connect();
            return await conn.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> Find(object criteria = null)
        {
            PropertyContainer properties = ParseProperties(criteria);
            string sqlPairs = GetSqlPairs(properties.AllNames, " AND ");
            using IDbConnection conn = _dbConnectionFactory.Connect();
            string sql = string.Format("SELECT * FROM {0} WHERE {1}", properties.TableName, sqlPairs);
            return await conn.QueryAsync<T>(sql, properties.AllPairs, commandType: CommandType.Text);
        }

        /// <exception cref="Exception">When there is no elements in list</exception>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<T> FindOne(object criteria = null)
        {
            PropertyContainer properties = ParseProperties(criteria);
            string sqlPairs = GetSqlPairs(properties.AllNames, " AND ");
            using IDbConnection conn = _dbConnectionFactory.Connect();
            string sql = string.Format("SELECT * FROM {0} WHERE {1} LIMIT 1", properties.TableName, sqlPairs);
            return await conn.QuerySingleAsync<T>(sql, properties.AllPairs, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            using IDbConnection conn = _dbConnectionFactory.Connect();
            return await conn.GetAllAsync<T>();
        }

        public async Task Delete(T entity)
        {
            PropertyContainer container = ParseProperties(entity);
            string sqlIdPairs = GetSqlPairs(container.IdNames);
            string sql = string.Format(@"DELETE FROM {0} 
            WHERE {1}
            ", container.TableName, sqlIdPairs);
            using IDbConnection conn = _dbConnectionFactory.Connect();
            await conn.QueryAsync(sql, container.IdPairs, commandType: CommandType.Text);
        }

        public async Task DeleteAll()
        {
            using IDbConnection conn = _dbConnectionFactory.Connect();
            if (!(await conn.DeleteAllAsync<T>()))
            {
                throw new Exception("Could not delete entity of type" + typeof(T));
            }
        }

        public async Task<T> Insert(T entity)
        {
            using IDbConnection conn = _dbConnectionFactory.Connect();

            PropertyContainer propertyContainer = ParseProperties(entity);
            string sql = string.Format(@"INSERT INTO {0} ({1}) 
            VALUES(@{2}) RETURNING id",
                propertyContainer.TableName,
                string.Join(", ", propertyContainer.ValueNames),
                string.Join(", @", propertyContainer.ValueNames));

            int id = (await conn.QueryAsync<int>
                (sql, propertyContainer.ValuePairs, commandType: CommandType.Text)).FirstOrDefault();

            entity.Id = (IdType)Convert.ChangeType(id, typeof(IdType));
            return entity;
        }

        public async Task Update(T entity)
        {
            PropertyContainer propertyContainer = ParseProperties(entity);
            string sqlIdPairs = GetSqlPairs(propertyContainer.IdNames);
            string sqlValuePairs = GetSqlPairs(propertyContainer.ValueNames);
            string sql = string.Format(@"UPDATE {0} 
            SET {1}
            WHERE {2}
            ", propertyContainer.TableName, sqlValuePairs, sqlIdPairs);
            using IDbConnection conn = _dbConnectionFactory.Connect();
            await conn.QueryAsync(sql, propertyContainer.AllPairs, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<T>> Query(string sql, CommandType type, object parameter = null)
        {
            using IDbConnection conn = _dbConnectionFactory.Connect();
            return await conn.QueryAsync<T>(sql, parameter, commandType: type);
        }

        public async Task<T> QueryFirstOrDefault(string sql, object parameter = null)
        {
            using IDbConnection conn = _dbConnectionFactory.Connect();
            return (await conn.QueryAsync<T>(sql, parameter)).FirstOrDefault();
        }

        /// <summary>
        /// Create a commaseparated list of value pairs on 
        /// the form: "key1=@value1, key2=@value2, ..."
        /// </summary>
        private static string GetSqlPairs(IEnumerable<string> keys, string separator = ", ")
        {
            List<string> pairs = keys.Select(key => string.Format("{0}=@{0}", key)).ToList();
            return string.Join(separator, pairs);
        }

        /// <summary>
        /// Retrieves a Dictionary with name and value 
        /// for all object properties matching the given criteria.
        /// </summary>
        private PropertyContainer ParseProperties(object obj)
        {
            PropertyContainer propertyContainer = new PropertyContainer();

            string typeName = (typeof(T).GetCustomAttributes(typeof(DapperTableAttribute), true).FirstOrDefault() as DapperTableAttribute).Name ?? typeof(T).Name;
            propertyContainer.TableName = typeName;

            string[] validKeyNames = new[] { "Id",
            string.Format("{0}Id", typeName), string.Format("{0}_Id", typeName) };

            System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo property in properties)
            {
                // Skip reference types (but still include string!)
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    continue;
                }

                // Skip methods specifically ignored
                if (property.IsDefined(typeof(DapperIgnoreAttribute), false))
                {
                    continue;
                }

                string name = property.Name;
                object value = obj.GetType().GetProperty(property.Name).GetValue(obj, null);

                if (property.IsDefined(typeof(DapperKeyAttribute), false) || validKeyNames.Contains(name))
                {
                    propertyContainer.AddId(name, value);
                }
                else
                {
                    propertyContainer.AddValue(name, value);
                }
            }

            return propertyContainer;
        }
    }
}
