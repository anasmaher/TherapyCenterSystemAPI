using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class TreatmentPlanConfiguration : IEntityTypeConfiguration<TreatmentPlan>
    {
        public void Configure(EntityTypeBuilder<TreatmentPlan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.TreatmentPlans)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Therapist)
                .WithMany(x => x.TreatmentPlans)
                .HasForeignKey(x => x.TherapistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
