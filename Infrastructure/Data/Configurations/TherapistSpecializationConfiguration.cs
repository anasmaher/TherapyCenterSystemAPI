using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TherapistSpecializationConfiguration : IEntityTypeConfiguration<TherapistSpecialization>
    {
        public void Configure(EntityTypeBuilder<TherapistSpecialization> builder)
        {
            builder.HasKey(x => new { x.TherapistId, x.Name });

            builder
                .HasOne(x => x.Therapist)
                .WithMany(t => t.Specializations)
                .HasForeignKey(x => x.TherapistId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name);
        }
    }
}
