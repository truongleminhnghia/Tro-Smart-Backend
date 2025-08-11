
namespace TroSmart.Domain.Entities
{
    public class Conversation : BaseEntity
    {
        public Guid Id { get; set; }

        // one to many with messages
        public virtual ICollection<Message>? Messages { get; set; }
        // many to one conversation members
        public virtual ICollection<ConversationMember>? ConversationMembers { get; set; }
    }
}