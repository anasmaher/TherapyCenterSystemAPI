using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class GroupSessionConfiguration : IEntityTypeConfiguration<GroupSession>
    {
        public void Configure(EntityTypeBuilder<GroupSession> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Therapist)
                .WithMany(x => x.GroupSessionsLed)
                .HasForeignKey(x => x.TherapistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupSessionPatients)
                .WithOne(x => x.GroupSession)
                .HasForeignKey(x => x.GroupSessionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
