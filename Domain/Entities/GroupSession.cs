namespace Domain.Entities
{
    internal class GroupSession
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TherapistId { get; set; }

        public bool IsActive { get; set; }

        public DateTime Date { get; set; }

        public List<int> PatientsIds { get; set; }

        public string Notes { get; set; }
    }
}
