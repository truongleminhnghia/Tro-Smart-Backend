
namespace TroSmart.Domain.Entities
{
    public class Voucher : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with voucher user
        public virtual ICollection<VoucherUser>? VoucherUsers { get; set; }
        // many to one with voucher transaction
        public virtual ICollection<VoucherTranscation>? VoucherTransactions { get; set; }
    }
}