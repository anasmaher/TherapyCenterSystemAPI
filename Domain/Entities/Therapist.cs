using Domain.Enums;

namespace Domain.Entities
{
    public class Therapist
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public GenderEnum Gender { get; set; }

        public int YearsOfExperience { get; set; }
        
        public bool IsAvailable { get; set; } = true;

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<GroupSession> GroupSessionsLed { get; set; }

        public virtual ICollection<ExerciseSubmission> AssignedExercises { get; set; }

        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; }

        public virtual ICollection<TherapistSpecialization> Specializations { get; set; } = new List<TherapistSpecialization>();

        public virtual ICollection<TherapistAvailability> Availabilities { get; set; } = new List<TherapistAvailability>();

    }
}
