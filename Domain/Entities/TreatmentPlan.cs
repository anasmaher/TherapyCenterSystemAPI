namespace Domain.Entities
{
    public class TreatmentPlan
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int TherapistId { get; set; }

        public string Diagnosis { get; set; }

        public string Goals { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Therapist Therapist { get; set; }

        public virtual ICollection<TreatmentPlanGoal> GoalsList { get; set; }


    }
}
