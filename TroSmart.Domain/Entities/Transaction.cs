
namespace TroSmart.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with subscription
        public Guid SubscriptionId { get; set; }
        public virtual Subscription? Subscription { get; set; }

        // one to many with payment
        public virtual ICollection<Payment>? Payments { get; set; }
        // one to many with voucher transaction
        public virtual ICollection<VoucherTranscation>? VoucherTransactions { get; set; }
    }
}