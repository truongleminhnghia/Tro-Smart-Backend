namespace TroSmart.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid Id { get; set; }

        public float Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public Guid ReviewerId { get; set; }
        public virtual Customer? Reviewer { get; set; }

        // many to one with property
        public Guid PropertyId { get; set; }
        public virtual Property? Property { get; set; }
    }
}