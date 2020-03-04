using Dapper;
using Dapper.Contrib.Extensions;
using Dort.Entity;
using Dort.Repository.Db;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dort.RepositoryImpl.Database
{
    public abstract class BaseRepository<T, IdType> : IBaseRepository<T, IdType> where T : class, IBaseEntity<IdType>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public virtual T Find(object id)
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            return conn.Get<T>(id);
        }

        public virtual IList<T> FindAll()
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            return conn.GetAll<T>().ToList();
        }

        public virtual void Delete(T entity)
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            if (!conn.Delete(entity))
            {
                throw new Exception("Could not delete entity of type" + typeof(T));
            }
        }

        public virtual void DeleteAll()
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            if (!conn.DeleteAll<T>())
            {
                throw new Exception("Could not delete entity of type" + typeof(T));
            }
        }

        public virtual T Insert(T entity)
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            entity.Id = (IdType)Convert.ChangeType(conn.Insert(entity), typeof(IdType));
            return entity;
        }

        public virtual void Update(T entity)
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            if (!conn.Update(entity))
            {
                throw new Exception("Could not update entity of type" + typeof(T));
            }
        }

        public virtual IList<T> Query(string sql, object parameter = null)
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            return conn.Query<T>(sql, parameter).ToList();
        }

        public virtual T QueryFirstOrDefault(string sql, object parameter = null)
        {
            using System.Data.IDbConnection conn = _dbConnectionFactory.Connect();
            return conn.Query<T>(sql, parameter).FirstOrDefault();
        }

    }
}
