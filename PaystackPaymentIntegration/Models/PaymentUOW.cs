using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.Interfaces;
using PaystackPaymentIntegration.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaystackPaymentIntegration.Models
{
    public class PaymentUOW : IUnitOfWork<PaymentContext>
    {
        private readonly PaymentContext _dbContext;

        public ITransactionRepository Transaction { get; set; }

        public PaymentUOW(PaymentContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext", "Null dbcontext passed.");

            Transaction = new TransactionRepository(_dbContext);
        }

        public PaymentUOW()
        {
            _dbContext = new PaymentContext();

            Transaction = new TransactionRepository(_dbContext);
        }

        public PaymentContext DBContext
        {
            get { return _dbContext; }
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}