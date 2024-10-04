using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }

    public static class TransactionExtentions
    {
        public static TransactionResponse ToTransactionResponse(this Transaction transaction)
        {
            return new TransactionResponse()
            {
                Id = transaction.Id,
                Category = transaction.Category,
                Type = transaction.Type,
                Cost = transaction.Cost,
                Date = transaction.Date,
                Description = transaction.Description
            };
        }
    }
}
