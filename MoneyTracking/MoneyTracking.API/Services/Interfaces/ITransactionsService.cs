using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;

namespace MoneyTracking.API.Services.Interfaces
{
    public interface ITransactionsService
    {
        /// <summary>
        /// Returns id.
        /// </summary>
        Task<string> CreateTransaction(CreateTransactionQuery query, string userId);

        Task DeleteTransaction(string transactionId);

        Task<TransactionInfo> UpdateTransaction(UpdateTransactionQuery query);

        Task<List<TransactionInfo>> GetTransactionsByCategoryId(string categoryId);

        Task<TransactionInfo> GetTransactionById(string transactionsId);

        Task<List<TransactionInfo>> GetTransactions(string userId);

    }
    
}