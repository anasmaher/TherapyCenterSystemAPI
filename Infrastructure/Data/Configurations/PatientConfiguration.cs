using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Appointments)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupSessions)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.TreatmentPlans)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ExerciseSubmissions)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Payments)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
