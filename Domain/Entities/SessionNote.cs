namespace Domain.Entities
{
    internal class SessionNote
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public int TherapistId { get; set; }

        public string Content { get; set; }

        public bool IsLocked { get; set; }
    }
}
