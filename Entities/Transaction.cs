namespace Entities
{
    /// <summary>
    /// Domain model for Transaction
    /// </summary>
    public class Transaction
    {
        public Guid Id { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
