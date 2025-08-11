using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TroSmart.Domain.Entities;

namespace TroSmart.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasColumnName("booking_id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(b => b.PropertyId)
                .HasColumnName("property_id")
                .IsRequired();

            builder.HasOne(b => b.Property)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PropertyId);

            builder.Property(b => b.PersonBookingId)
                .HasColumnName("person_booking_id")
                .IsRequired();

            builder.HasOne(b => b.PersonBooking)
                .WithMany(p => p.PersonBookings)
                .HasForeignKey(b => b.PersonBookingId)     
                .HasPrincipalKey(p => p.Id)                    
                .OnDelete(DeleteBehavior.NoAction)               
                .HasConstraintName("FK_bookings_person_booking");

            builder.Property(b => b.PersonScheduledId)
                .HasColumnName("person_scheduled_id")
                .IsRequired();


            builder.HasOne(b => b.PersonScheduled)
                .WithMany(p => p.ScheduledBookings)
                .HasForeignKey(b => b.PersonScheduledId)         
                .HasPrincipalKey(p => p.Id)                      
                .OnDelete(DeleteBehavior.NoAction)             
                .HasConstraintName("FK_bookings_person_scheduled");

            builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(b => b.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}