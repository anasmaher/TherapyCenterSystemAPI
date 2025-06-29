using Domain.Enums;

namespace Domain.Entities
{
    public class ExerciseSubmission
    {
        public int Id { get; set; }

        public int ExerciseTemplateId { get; set; }

        public int PatientId { get; set; }

        public int AssignedByTherapistId { get; set; }

        public string ResponseJson { get; set; }    

        public string ReflectionNote { get; set; }

        public ExerciseStatusEnum Status { get; set; }

        public virtual ExerciseTemplate ExerciseTemplate { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Therapist AssignedByTherapist { get; set; }


    }
}
