using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("messages");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("message_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(m => m.SenderId)
                .HasColumnName("sender_id")
                .IsRequired();

            builder.HasOne(m => m.Sender)
                .WithMany(a => a.SenderMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ConversationId)
                .HasColumnName("conversation_id")
                .IsRequired();

            builder.HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(m => m.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}