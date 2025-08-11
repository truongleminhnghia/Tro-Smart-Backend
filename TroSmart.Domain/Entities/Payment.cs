namespace TroSmart.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with transaction
        public Guid TransactionId { get; set; }
        public virtual Transaction? Transaction { get; set; }

        // many to one with account
        public Guid AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}