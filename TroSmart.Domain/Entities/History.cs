namespace TroSmart.Domain.Entities
{
    public class History : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with property
        public Guid PropertyId { get; set; }
        public virtual Property? Property { get; set; }

        // many to one with listing
        public Guid ListingId { get; set; }
        public virtual Listing? Listing { get; set; }
    }
}