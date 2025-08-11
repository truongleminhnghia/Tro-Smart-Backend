
namespace TroSmart.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ListingId { get; set; }
        public virtual Listing? Listing { get; set; }
    }
}