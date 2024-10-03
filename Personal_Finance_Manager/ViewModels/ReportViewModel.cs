using ServiceContracts.DTO;

namespace Personal_Finance_Manager.ViewModels
{
    public class ReportViewModel
    {
        public IEnumerable<TransactionResponse>? Transactions { get; set; }
        public IEnumerable<CategoryResponse>? Categories { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Type { get; set; }
        public string? Category { get; set; }
        public ReportViewModel()
        {
            LastDate = DateTime.Today;
        }
    }
}
