using PayStack.Net;
using PaystackPaymentIntegration.Models.DTOs.Readonly;
using PaystackPaymentIntegration.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaystackPaymentIntegration.Models.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<transaction_record, int>
    {
        Task<List<TransactionDTO>> GetAllTransactions();
        TransactionInitializeResponse InitializeTransaction(string email, int amount);
        TransactionVerifyResponse VerifyTransaction(string tranxRef);
        TransactionFetchResponse FetchTransaction(string transactionId);
        TransactionListResponse AllTransactions();
    }
}
