namespace TroSmart.Domain.Entities
{
    public class Attention : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with property
        public Guid ListingId { get; set; }
        public virtual Listing? Listing { get; set; }

        // many to one with property
        public Guid PropertyId { get; set; }
        public virtual Property? Property { get; set; }

        // many to one with account
        public Guid CustomerAttentionId { get; set; }
        public virtual Customer? CustomerAttention { get; set; }
    }
}