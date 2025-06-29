namespace Domain.Entities
{
    public class GroupSession
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TherapistId { get; set; }

        public bool IsActive { get; set; }

        public DateTime Date { get; set; }

        public List<int> PatientsIds { get; set; }

        public string Notes { get; set; }

        public virtual Therapist Therapist { get; set; }

        public virtual ICollection<GroupSessionParticipant> GroupSessionPatients { get; set; }
    }
}
