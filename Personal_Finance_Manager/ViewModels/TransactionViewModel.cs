using ServiceContracts.DTO;

namespace Personal_Finance_Manager.ViewModels
{
    public class TransactionViewModel
    {
        public List<TransactionResponse>? Transactions { get; set; }
        public List<string?> CategoryNames { get; set; }
    }
}