namespace Entities
{
    /// <summary>
    /// Domain model for Report
    /// </summary>
    public class Report
    {
        public string? Category { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Type { get; set; }
    }
}
