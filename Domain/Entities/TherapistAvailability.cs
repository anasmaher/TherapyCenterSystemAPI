namespace Domain.Entities
{
    public class TherapistAvailability
    {
        public int Id { get; set; }

        public int TherapistId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public virtual Therapist Therapist { get; set; }
    }
}
