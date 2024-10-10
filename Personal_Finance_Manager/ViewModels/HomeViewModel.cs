using Entities;
using ServiceContracts.DTO;

namespace Personal_Finance_Manager.ViewModels
{
    public class HomeViewModel
    {
        public bool IsConnected { get; set; }
        public string ConnectionStatus { get; set; }
        public string ConnectionStatusColor { get; set; }
        public string? ErrorMessage { get; set; }
        public List<CategoryResponse> Categories { get; set; }
        public List<TransactionResponse> Transactions { get; set; }
        public int TransactionCount { get; set; }
    }

}
