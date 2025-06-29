namespace Domain.Entities
{
    internal class TreatmentPlan
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int TherapistId { get; set; }

        public string Diagnosis { get; set; }

        public string Goals { get; set; }
    }
}
