using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Services;
using Entities;

namespace Personal_Finance_Manager.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsApiController
    {
        public TransactionsApiController(FinanceService financeService) 
        {
            _financeService = financeService;
        }

        private readonly FinanceService _financeService;

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Transaction> GetTransactions(FinanceService financeService)
        {
            return _financeService.GetTransactions();
        }
    }
}
