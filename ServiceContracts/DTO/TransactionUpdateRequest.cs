using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class TransactionUpdateRequest
    {
        [Required(ErrorMessage = "Transaction Id cannot be blank.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Category cannot be blank.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Transaction Type cannot be blank.")]
        public TransactionTypeOptions? Type { get; set; }

        [Required(ErrorMessage = "Cost cannot be blank.")]
        [RegularExpression(@"/^\d*(\.|,|(\.\d{1,2})|(,\d{1,2}))?$/gm", ErrorMessage = "Invalid Cost.")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Date cannot be blank.")]
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
