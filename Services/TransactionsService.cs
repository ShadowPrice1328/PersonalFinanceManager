using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Data;
using Services.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly AppDbContext _appDbContext;
        public TransactionsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public TransactionResponse AddTransaction(TransactionAddRequest? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(TransactionAddRequest));

            ValidationHelper.ModelValidation(request);

            Transaction transaction = request.ToTransaction();

            _appDbContext.Transactions.Add(transaction);
            _appDbContext.SaveChanges();

            return transaction.ToTransactionResponse();
        }

        public bool DeleteTransaction(Guid? guid)
        {
            if (!guid.HasValue)
                return false;

            Transaction? transaction = _appDbContext.Transactions.FirstOrDefault(t => t.Id == guid.Value);

            if (transaction == null)
                return false;

            _appDbContext.Transactions.Remove(transaction);
            _appDbContext.SaveChanges();

            return true;
        }

        public TransactionResponse? GetTransactionByTransactionId(Guid? transactionId)
        {
            if (!transactionId.HasValue) throw new ArgumentNullException(nameof(transactionId));

            return _appDbContext.Transactions.FirstOrDefault(t => t.Id == transactionId)?.ToTransactionResponse() ?? null;
        }

        public List<TransactionResponse> GetTransactions()
        {
            return _appDbContext.Transactions.Select(t => t.ToTransactionResponse()).ToList();
        }

        public TransactionResponse UpdateTransaction(TransactionUpdateRequest? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);

            Transaction? transaction = _appDbContext.Transactions.FirstOrDefault(t => t.Id == request.Id)
                ?? throw new ArgumentException("Category with given Id does not exist", nameof(request));

            transaction.Category = request.Category;
            transaction.Description = request.Description;
            transaction.Cost = request.Cost;
            transaction.Date = request.Date;

            _appDbContext.SaveChanges();

            return transaction.ToTransactionResponse();
        }
    }
}
