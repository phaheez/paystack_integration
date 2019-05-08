using PayStack.Net;
using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.DTOs.Readonly;
using PaystackPaymentIntegration.Models.Entities;
using PaystackPaymentIntegration.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaystackPaymentIntegration.Models.Repository
{
    public class TransactionRepository : BaseRepository<transaction_record, int>, ITransactionRepository
    {
        private DbContext _dbcontxt;

        public TransactionRepository(PaymentContext dbContext) : base(dbContext)
        {
            _dbcontxt = dbContext;
        }

        public async Task<List<TransactionDTO>> GetAllTransactions()
        {
            var result = await GetAll()
                .Select(x => new TransactionDTO
                {
                    transaction_id = x.transaction_id,
                    email = x.email,
                    amount = x.amount,
                    reference = x.reference,
                    created_date = x.created_date
                }).ToListAsync();

            return result;
        }

        public TransactionInitializeResponse InitializeTransaction(string email, int amount)
        {
            var secretKey = ConfigurationManager.AppSettings["PayStackSecret"];
            var transactionAPI = new PayStackApi(secretKey);

            var response = transactionAPI.Transactions.Initialize(email, (amount * 100));

            return response;
        }

        public TransactionVerify.Data VerifyTransaction(string tranxRef)
        {
            var secretKey = ConfigurationManager.AppSettings["PayStackSecret"].ToString();

            var transactionAPI = new PayStackApi(secretKey);

            var response = transactionAPI.Transactions.Verify(tranxRef);

            return response.Data;
        }
    }
}