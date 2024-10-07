using Microsoft.AspNetCore.Mvc;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Personal_Finance_Manager.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsApiController
    {
        private readonly ITransactionsService _transactionsService;
        public TransactionsApiController(ITransactionsService transactionsService) 
        {
            _transactionsService = transactionsService;
        }

        [Route("get-all")]
        [HttpGet]
        public List<TransactionResponse> GetTransactions()
        {
            return _transactionsService.GetTransactions();
        }
    }
}
