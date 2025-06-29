using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class TherapistConfiguration : IEntityTypeConfiguration<Therapist>
    {
        public void Configure(EntityTypeBuilder<Therapist> builder)
        {
            builder.HasIndex(x => x.Id);

            builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Therapist)
            .HasForeignKey(x => x.TherapistId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupSessionsLed)
                .WithOne(x => x.Therapist)
                .HasForeignKey(x => x.TherapistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.TreatmentPlans)
                .WithOne(x => x.Therapist)
                .HasForeignKey(x => x.TherapistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.AssignedExercises)
                .WithOne(x => x.AssignedByTherapist)
                .HasForeignKey(x => x.AssignedByTherapistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
