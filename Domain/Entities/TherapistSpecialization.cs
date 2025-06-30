namespace Domain.Entities
{
    public class TherapistSpecialization
    {
        public int TherapistId { get; set; }

        public string Name { get; set; }

        public Therapist Therapist { get; set; }
    }
}
