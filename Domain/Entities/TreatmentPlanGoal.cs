using Domain.Enums;

namespace Domain.Entities
{
    internal class TreatmentPlanGoal
    {
        public int Id { get; set; }

        public int TreatmentPlanId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsAchieved { get; set; }

        public string ProgressNotes { get; set; }

        public DateTime CreatedAt { get; set; }

        public TreatmentPlanGoalStatusEnum Status { get; set; }
    }
}
