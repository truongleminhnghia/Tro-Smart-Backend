using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("conversations");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("conversation_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}