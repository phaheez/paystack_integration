using PaystackPaymentIntegration.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaystackPaymentIntegration.Models
{
    public interface IUnitOfWork<out TContext> : IDisposable where TContext : BaseContext<TContext>
    {
        Task<int> CompleteAsync();
        TContext DBContext { get; }
    }
}
