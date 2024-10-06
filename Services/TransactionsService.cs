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

        public List<TransactionResponse> GetFilteredTransactions(string filterBy, string? filterString)
        {
            List<TransactionResponse> allTransactions = GetTransactions();
            List<TransactionResponse> filteredTransactions = allTransactions;

            if (string.IsNullOrEmpty(filterBy) || string.IsNullOrEmpty(filterString))
                return filteredTransactions;

            switch (filterBy)
            {
                case nameof(Transaction.Category):
                    filteredTransactions = allTransactions.Where(t => string.IsNullOrEmpty(t.Category) ||
                    t.Category == filterString)
                    .ToList();
                    break;

                case nameof(Transaction.Description):
                    filteredTransactions = allTransactions.Where(t => string.IsNullOrEmpty(t.Description) ||
                    t.Description == filterString)
                    .ToList();
                    break;

                case nameof(Transaction.Type):
                    filteredTransactions = allTransactions.Where(t => string.IsNullOrEmpty(t.Type) ||
                    t.Type == filterString)
                    .ToList();
                    break;

                case nameof(Transaction.Cost):
                    filteredTransactions = allTransactions.Where(t => string.IsNullOrEmpty(t.Cost.ToString()) ||
                    t.Cost == Convert.ToDecimal(filterString))
                    .ToList();
                    break;

                case nameof(Transaction.Date):
                    filteredTransactions = allTransactions.Where(t => string.IsNullOrEmpty(t.Date.ToString()) ||
                    t.Date == DateTime.Parse(filterString))
                    .ToList();
                    break;

                default: filteredTransactions = allTransactions; break;
            }

            return filteredTransactions;
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
