using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class ExerciseTemplateConfiguration
    {
        public void Configure(EntityTypeBuilder<ExerciseTemplate> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
