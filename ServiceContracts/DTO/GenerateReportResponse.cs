using Entities;
using ServiceContracts.CustromValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class GenerateReportResponse
    {
        public string? Category { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Type { get; set; }
        public List<TransactionResponse> SelectedTransactions { get; set; }
        public Dictionary<string, decimal> CategoryCosts { get; set; }
        public decimal CategoryTotalCost { get; set; }
    }
    public static class ReportExtentions
    {
        public static GenerateReportResponse ToGenerateResponse(this Report report,
                                                    List<TransactionResponse> transactions,
                                                    Dictionary<string, decimal> categoryCost)
        {
            return new GenerateReportResponse
            {
                Category = report.Category,
                FirstDate = report.FirstDate,
                LastDate = report.LastDate,
                Type = report.Type,
                SelectedTransactions = transactions,
                CategoryCosts = categoryCost,
                CategoryTotalCost = transactions.Sum(t => t.Cost)
            };
        }
    }
}
