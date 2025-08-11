
using TroSmart.Domain.Enums;

namespace TroSmart.Domain.Entities
{
    public class Account : BaseEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public AccountStatus Status { get; set; }
        // many to one with role
        public Guid RoleId { get; set; }
        public virtual Role? Role { get; set; }

        // one to one with user
        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        // on to one with employee
        public Guid? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        // one to many with conversation member
        public Guid? ConversationMemberId { get; set; }
        public virtual ICollection<ConversationMember>? ConversationMembers { get; set; }

        //many to one with Listing
        public virtual ICollection<Listing>? ListingPost { get; set; }

        // many to one with Payment
        public virtual ICollection<Payment>? Payments { get; set; }

        // many to one with person booking
        public virtual ICollection<Booking>? PersonBookings { get; set; }
        // many to one with sheduled booking
        public virtual ICollection<Booking>? ScheduledBookings { get; set; }

        // many to one with message
        public virtual ICollection<Message>? SenderMessages { get; set; }
    }
}