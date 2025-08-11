namespace TroSmart.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid Id { get; set; }

        // many to one with conversation
        public Guid ConversationId { get; set; }
        public virtual Conversation? Conversation { get; set; }

        // many to one with sender
        public Guid SenderId { get; set; }
        public virtual Account? Sender { get; set; }
    }
}