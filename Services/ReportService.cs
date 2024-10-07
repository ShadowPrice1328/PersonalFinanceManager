using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Data;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly ITransactionsService _transactionsService;
        public ReportService(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }
        public GenerateReportResponse GenerateReport(GenerateReportRequest? model, bool withCategory)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            ValidationHelper.ModelValidation(model);
            Report report = model.ToReport();

            List<TransactionResponse> selectedTransaction = _transactionsService
                .GetTransactionBetweenTwoDates(model.FirstDate, model.LastDate)
                .Where(t => t.Type == model.Type).ToList();

            if (withCategory)
                selectedTransaction = selectedTransaction.Where(t => t.Category == model.Category).ToList();

            var categoryCosts = selectedTransaction
                .Where(t => t.Category != null)
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key!, g => g.Sum(t => t.Cost));

            GenerateReportResponse response = report.ToGenerateResponse(selectedTransaction, categoryCosts);

            return response;
        }
    }
}
