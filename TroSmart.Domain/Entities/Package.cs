namespace TroSmart.Domain.Entities
{
    public class Package : BaseEntity
    {
        public Guid Id { get; set; }

        // one to many with subscription
        public virtual ICollection<Subscription>? Subscriptions { get; set; }
    }
}