namespace TroSmart.Domain.Entities
{
    public class VoucherUser : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid VoucherId { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}