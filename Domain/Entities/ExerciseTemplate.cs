using Domain.Enums;

namespace Domain.Entities
{
    public class ExerciseTemplate
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Instructions { get; set; }

        public string Example { get; set; }

        public string InputSchemaJson { get; set; }

        public ExerciseTypeEnum Type { get; set; }
    }
}
