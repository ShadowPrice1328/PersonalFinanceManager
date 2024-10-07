using Entities;
using ServiceContracts.CustromValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class GenerateReportRequest
    {
        public string? Category { get; set; }

        [Required(ErrorMessage = "First Date cannot be blank.")]
        public DateTime FirstDate { get; set; }

        [Required(ErrorMessage = "Last Date cannot be blank.")]
        [LastDateValidator]
        public DateTime LastDate { get; set; }

        [Required(ErrorMessage = "Transaction Type cannot be null.")]
        public string Type { get; set; }
        public Report ToReport()
        {
            return new Report
            {
                Category = Category,
                FirstDate = FirstDate,
                LastDate = LastDate,
                Type = Type
            };
        }
    }
}
