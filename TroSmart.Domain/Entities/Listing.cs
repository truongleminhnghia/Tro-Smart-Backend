
namespace TroSmart.Domain.Entities
{
    public class Listing : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with property
        public Guid PropertyId { get; set; }
        public virtual Property? Property { get; set; }

        // many to one with user
        public Guid PostById { get; set; }
        public virtual Account? PostBy { get; set; }

        public Guid? ApprovedById { get; set; }
        public virtual Employee? ApprovedBy { get; set; }

        // many to one with contract
        public Guid? ContactId { get; set; }
        public virtual ICollection<Contact>? Contacts { get; set; }

        // one to many with subscription
        public virtual ICollection<Subscription>? Subscriptions { get; set; }
        //one to many with attention
        public virtual ICollection<Attention>? Attentions { get; set; }
        // one to many with history
        public virtual ICollection<History>? Histories { get; set; }
    }
}