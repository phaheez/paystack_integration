using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaystackPaymentIntegration.Models.Interfaces
{
    public interface IBaseRepository<T, in Tkey> where T : class
    {
        void Add(T entity);
        IQueryable<T> GetAll();
        T Get(Tkey key);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> wherePredicate);
        Task<bool> ExistWhereAsync(Expression<Func<T, bool>> wherePredicate);
        void Override(T destination, T source);
        Task<int> CompleteAsync();
    }
}
