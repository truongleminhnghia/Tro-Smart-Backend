
using TroSmart.Domain.Enums;

namespace TroSmart.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public GenderName Gender { get; set; }
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }

        // many to one with Approve
        public virtual ICollection<Listing>? ListingApprove { get; set; }
    }
}