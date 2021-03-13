using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.API.Services.Interfaces;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        
        private readonly ITransactionsService _transactionsService;
        private readonly UserManager<AppUser> _userManager;

        public TransactionsController(ITransactionsService transactionsService, UserManager<AppUser> userManager)
        {
            _transactionsService = transactionsService;
            _userManager = userManager;
        }
        
        [HttpPost]
        public Task<string> CreateTransaction(CreateTransactionQuery query)
        {
            var userId = _userManager.GetUserId(User);
            return _transactionsService.CreateTransaction(query, userId);
        }
        
        [HttpDelete]
        [Route("{transactionId}")]
        public async Task<IActionResult> DeleteTransaction([Required]string transactionId)
        {
            await _transactionsService.DeleteTransaction(transactionId);
            return StatusCode(204);
        }

        [HttpPut]
        public async Task<TransactionInfo> UpdateTransaction(UpdateTransactionQuery query)
        {
            return await _transactionsService.UpdateTransaction(query);
        }

        [HttpGet]
        [Route("bycategoryid/{categoryId}")]
        public async Task<List<TransactionInfo>> GetTransactionsByCategoryId([Required]string categoryId)
        {
            return await _transactionsService.GetTransactionsByCategoryId(categoryId);
        }

        [HttpGet]
        [Route("{transactionsId}")]
        public async  Task<TransactionInfo> GetTransactionById([Required]string transactionsId)
        {
            return await _transactionsService.GetTransactionById(transactionsId);
        }

        [HttpGet]
        public async Task<List<TransactionInfo>> GetTransactions()
        {
            var userId = _userManager.GetUserId(User);
            return await _transactionsService.GetTransactions(userId);
        }
        
    }
}