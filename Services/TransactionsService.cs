using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class TransactionsService : ITransactionsService
    {
        public TransactionResponse AddTransaction(TransactionAddRequest? request)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(Guid? guid)
        {
            throw new NotImplementedException();
        }

        public TransactionResponse GetTransactionByTransactionId(Guid? transactionId)
        {
            throw new NotImplementedException();
        }

        public List<TransactionResponse> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public TransactionResponse UpdateTransaction(TransactionUpdateRequest? request)
        {
            throw new NotImplementedException();
        }
    }
}
