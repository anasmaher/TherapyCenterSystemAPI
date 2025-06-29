using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class SessionNoteConfiguration : IEntityTypeConfiguration<SessionNote>
    {
        public void Configure(EntityTypeBuilder<SessionNote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Appointment)
                .WithOne(x => x.SessionNote)
                .HasForeignKey<SessionNote>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
