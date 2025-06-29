namespace Domain.Entities
{
    public class SessionNote
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public int TherapistId { get; set; }

        public string Content { get; set; }

        public bool IsLocked { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
