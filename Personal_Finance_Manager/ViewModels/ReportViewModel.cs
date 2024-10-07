using ServiceContracts.DTO;

namespace Personal_Finance_Manager.ViewModels
{
    public class ReportViewModel
    {
        public DateTime? FirstDate { get; set; }
        public DateTime LastDate { get; set; } = DateTime.Today;
        public string Type { get; set; }
        public string? Category { get; set; }
    }
}
