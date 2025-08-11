
namespace TroSmart.Domain.Entities
{
    public class ConversationMember : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public virtual Conversation? Conversation { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}