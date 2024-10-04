namespace Entities
{
    /// <summary>
    /// Domain model for Category
    /// </summary>
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
