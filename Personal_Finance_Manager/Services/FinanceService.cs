using Entities;
using Personal_Finance_Manager.Converters;
using Personal_Finance_Manager.Data;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Personal_Finance_Manager.Services
{
    public class FinanceService
    {
        private readonly AppDbContext _appDbContext;
        public FinanceService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _appDbContext.Categories.ToList();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _appDbContext.Transactions.ToList();
        }

        public Category GetCategory(string Name)
        {
            return _appDbContext.Categories.FirstOrDefault(x => x.Name == Name);
        }
    }
}