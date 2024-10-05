using Entities;

namespace Personal_Finance_Manager.ViewModels
{
    public class HomeViewModel
    {
        public bool IsConnected { get; set; }
        public string ConnectionStatus { get; set; }
        public string ConnectionStatusColor { get; set; }
        public string? ErrorMessage { get; set; }
        public List<Category>? Categories { get; set; }
        public int TransactionCount { get; set; }
    }

}
