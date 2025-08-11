
namespace TroSmart.Domain.Entities
{
    public class VoucherTranscation : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid VoucherId { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public Guid TransactionId { get; set; }
        public virtual Transaction? Transaction { get; set; }
    }
}