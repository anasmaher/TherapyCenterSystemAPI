using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int PatientId { get; set; }

        public int TherapistId { get; set; }

        public string Notes { get; set; }

        public AppointmentStatusEnum Status { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Therapist Therapist { get; set; }

        public virtual PaymentTransaction Payment { get; set; }

        public virtual SessionNote SessionNote { get; set; }
    }
}
