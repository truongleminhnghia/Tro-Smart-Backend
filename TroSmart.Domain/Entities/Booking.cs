
namespace TroSmart.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with property
        public Guid PropertyId { get; set; }
        public virtual Property? Property { get; set; }

        // many to one with account
        public Guid PersonBookingId { get; set; }
        public virtual Account? PersonBooking { get; set; }

        // many to one with account
        public Guid PersonScheduledId { get; set; }
        public virtual Account? PersonScheduled { get; set; }
    }
}