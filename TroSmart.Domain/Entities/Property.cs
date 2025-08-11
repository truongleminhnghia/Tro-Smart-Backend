
namespace TroSmart.Domain.Entities
{
    public class Property : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with address
        public Guid AddressId { get; set; }
        public virtual Address? Address { get; set; }

        // one to many with images
        public virtual ICollection<Image>? Images { get; set; }
        // one to many with Listings
        public virtual ICollection<Listing>? Listings { get; set; }
        // one to many with Reviews
        public virtual ICollection<Review>? Reviews { get; set; }
        // one to many with booking
        public virtual ICollection<Booking>? Bookings { get; set; }
        // one to many with history
        public virtual ICollection<History>? Histories { get; set; }
        // one to many with attention
        public virtual ICollection<Attention>? Attentions { get; set; }

    }
}