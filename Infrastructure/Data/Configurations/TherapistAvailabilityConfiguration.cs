using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TherapistAvailabilityConfiguration : IEntityTypeConfiguration<TherapistAvailability>
    {
        public void Configure(EntityTypeBuilder<TherapistAvailability> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DayOfWeek)
                .IsRequired();

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.HasOne(x => x.Therapist)
                .WithMany(t => t.Availabilities)
                .HasForeignKey(x => x.TherapistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
