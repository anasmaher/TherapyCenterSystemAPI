using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class ExerciseSubmissionConfiguration : IEntityTypeConfiguration<ExerciseSubmission>
    {
        public void Configure(EntityTypeBuilder<ExerciseSubmission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.ExerciseSubmissions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ExerciseTemplate)
                .WithMany()
                .HasForeignKey(x => x.ExerciseTemplateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AssignedByTherapist)
                .WithMany(x => x.AssignedExercises)
                .HasForeignKey(x => x.AssignedByTherapistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
