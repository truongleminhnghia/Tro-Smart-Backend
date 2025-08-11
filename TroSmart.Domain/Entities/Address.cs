
namespace TroSmart.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid Id { get; set; }
        public string AddressDetails { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public float? LocationLatitude { get; set; }
        public float? LocationLongitude { get; set; }
        public virtual ICollection<Property>? Properties { get; set; }
    }
}