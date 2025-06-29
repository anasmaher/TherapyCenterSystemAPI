namespace Domain.Entities
{
    public class GroupSessionParticipant
    {
        public int GroupSessionId { get; set; }

        public int PatientId { get; set; }

        public virtual GroupSession GroupSession { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
