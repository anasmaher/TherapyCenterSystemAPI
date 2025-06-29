using Domain.Enums;

namespace Domain.Entities
{
    internal class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int PatientId { get; set; }

        public int TherapistId { get; set; }

        public string Notes { get; set; }

        public AppointmentStatusEnum Status { get; set; }
    }
}
