using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class ConversationMemberConfiguration : IEntityTypeConfiguration<ConversationMember>
    {
        public void Configure(EntityTypeBuilder<ConversationMember> builder)
        {
            builder.ToTable("conversation_members");

            builder.HasKey(cm => cm.Id);
            builder.Property(cm => cm.Id)
                .HasColumnName("conversation_member_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(cm => cm.ConversationId)
                .HasColumnName("conversation_id")
                .IsRequired();

            builder.HasOne(cm => cm.Conversation)
                .WithMany(c => c.ConversationMembers)
                .HasForeignKey(cm => cm.ConversationId);

            builder.Property(cm => cm.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(cm => cm.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        }
    }
}