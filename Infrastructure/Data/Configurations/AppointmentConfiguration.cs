using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Therapist)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.TherapistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SessionNote)
                .WithOne(x => x.Appointment)
                .HasForeignKey<SessionNote>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Payment)
                .WithOne(x => x.Appointment)
                .HasForeignKey<PaymentTransaction>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
