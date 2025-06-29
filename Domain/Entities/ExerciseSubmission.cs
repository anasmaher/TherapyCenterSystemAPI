using Domain.Enums;

namespace Domain.Entities
{
    internal class ExerciseSubmission
    {
        public int Id { get; set; }

        public int ExerciseTemplateId { get; set; }

        public int PatientId { get; set; }

        public int AssignedByTherapistId { get; set; }

        public string ResponseJson { get; set; }    

        public string ReflectionNote { get; set; }

        public ExerciseStatusEnum Status { get; set; }
    }
}
