using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class GroupSessionParticipantConfiguration : IEntityTypeConfiguration<GroupSessionParticipant>
    {
        public void Configure(EntityTypeBuilder<GroupSessionParticipant> builder)
        {
            builder.HasKey(x => new { x.GroupSessionId, x.PatientId });

            builder.HasOne(x => x.GroupSession)
                .WithMany(x => x.GroupSessionPatients)
                .HasForeignKey(x => x.GroupSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.GroupSessions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
