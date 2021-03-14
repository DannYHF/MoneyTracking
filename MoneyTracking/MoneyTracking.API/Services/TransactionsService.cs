using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyTracking.API.Helpers.ApiExceptions;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.API.Services.Interfaces;
using MoneyTracking.Data;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TransactionsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<string> CreateTransaction(CreateTransactionQuery query, string userId)
        {
            if (query.Spent <= 0 || query.Spent >= double.MaxValue)
                throw new InvalidRequestException($"Invalid {nameof(query.Spent)} : {query.Spent}.");
            
            var category = _context.Categories.SingleOrDefault(c=>c.Id == query.CategoryId);
            if (category == null)
                throw new NotFoundException(query.CategoryId);

            Transaction transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Spent = query.Spent,
                CategoryId = category.Id,
                AppUserId = userId
                
            };
            
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction.Id;
        }

        public async Task DeleteTransaction(string transactionId)
        {
            var transactions = _context.Transactions.SingleOrDefault(c=>c.Id == transactionId);
            
            if (transactions == null)
                throw new NotFoundException(transactionId);

            _context.Transactions.Remove(transactions);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionInfo> UpdateTransaction(UpdateTransactionQuery query)
        {
            Transaction transaction = await _context.Transactions
                .SingleOrDefaultAsync(t => t.Id == query.TransactionId);

            if (transaction == null)
                throw new NotFoundException(query.TransactionId);

            if (query.NewSpent <= 0 || query.NewSpent > double.MaxValue)
                throw new InvalidRequestException($"Invalid {nameof(query.NewSpent)} : {query.NewSpent}");
            
            transaction.Spent = query.NewSpent;
            await _context.SaveChangesAsync();

            return _mapper.Map<TransactionInfo>(transaction);
        }

        public async Task<List<TransactionInfo>> GetTransactionsByCategoryId(string categoryId)
        {
            return await _context.Transactions
                .Where(t => t.CategoryId == categoryId)
                .Include(x=>x.Category)
                .Select(t => new TransactionInfo
                {
                    Id = t.Id,
                    Category = _mapper.Map<CategoryInfo>(t.Category),
                    Spent = t.Spent,
                    CreationTime = t.CreationTime
                })
                .ToListAsync();
        }

        public async Task<TransactionInfo> GetTransactionById(string transactionsId)
        {
            Transaction transaction = await _context.Transactions
                .Include(x=>x.Category)
                .SingleOrDefaultAsync(t=>t.Id == transactionsId);
            if (transaction == null)
                throw new NotFoundException(transactionsId);

            return _mapper.Map<TransactionInfo>(transaction);
        }

        public async Task<List<TransactionInfo>> GetTransactions(string userId)
        {
            return await _context.Transactions
                .Where(t => t.AppUserId == userId)
                .Include(x=>x.Category)
                .Select(t => new TransactionInfo
                {
                    Id = t.Id,
                    Category = _mapper.Map<CategoryInfo>(t.Category),
                    Spent = t.Spent,
                    CreationTime = t.CreationTime,
                })
                .ToListAsync();
        }
    }
}