using PaystackPaymentIntegration.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace PaystackPaymentIntegration.Models
{
    public class BaseRepository<T, Tkey> : IBaseRepository<T, Tkey> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T Get(Tkey key)
        {
            return _dbContext.Set<T>().Find(key);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> wherePredicate)
        {
            return _dbContext.Set<T>().Where(wherePredicate);
        }

        public async Task<bool> ExistWhereAsync(Expression<Func<T, bool>> wherePredicate)
        {
            return await _dbContext.Set<T>().Where(wherePredicate).AnyAsync();
        }

        public void Override(T destination, T source)
        {
            _dbContext.Entry(destination).CurrentValues.SetValues(source);
        }
    }
}