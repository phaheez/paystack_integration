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
    public class BaseRepository<T, Tkey> : IBaseRepository<T, Tkey>, IDisposable where T : class
    {
        private DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Allowerialization = true;
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

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync(); 
        }

        public void Override(T destination, T source)
        {
            _dbContext.Entry(destination).CurrentValues.SetValues(source);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public virtual bool Allowerialization
        {
            get
            {
                return _dbContext.Configuration.ProxyCreationEnabled;
            }
            set
            {
                _dbContext.Configuration.ProxyCreationEnabled = !value;
            }
        }
    }
    /*public class BaseRepository<T> : IDisposable where T : DbContext, new()
    {
        private T _dataContext;

        public virtual T DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = new T();
                    Allowerialization = true;
                }
                return _dataContext;
            }
        }

        public virtual bool Allowerialization
        {
            get
            {
                return _dataContext.Configuration.ProxyCreationEnabled;
            }
            set
            {
                _dataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }

        public void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }
    }*/
}