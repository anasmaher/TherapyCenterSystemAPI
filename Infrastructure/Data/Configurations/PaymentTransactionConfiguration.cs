using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations
{
    internal class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Appointment)
                .WithOne(x => x.Payment)
                .HasForeignKey<PaymentTransaction>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
