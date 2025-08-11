namespace TroSmart.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }

        // many to one with listing
        public Guid ListingId { get; set; }
        public virtual Listing? Listing { get; set; }

        // many to ơn with package
        public Guid PackageId { get; set; }
        public virtual Package? Package { get; set; }

        // one to many with transaction
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}