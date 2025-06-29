using Domain.Enums;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderEnum Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int AssignedTherapistId { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<GroupSessionParticipant> GroupSessions { get; set; }

        public virtual ICollection<ExerciseSubmission> ExerciseSubmissions { get; set; }

        public virtual ICollection<PaymentTransaction> Payments { get; set; }

        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; }
    }
}
