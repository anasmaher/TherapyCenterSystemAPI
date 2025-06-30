using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Patient> Patients { get; }
        DbSet<Therapist> Therapists { get; }
        DbSet<Appointment> Appointments { get; }
        DbSet<SessionNote> SessionNotes { get; }
        DbSet<TreatmentPlan> TreatmentPlans { get; }
        DbSet<TreatmentPlanGoal> TreatmentPlanGoals { get; }
        DbSet<ExerciseTemplate> ExerciseTemplates { get; }
        DbSet<ExerciseSubmission> ExerciseSubmissions { get; }
        DbSet<GroupSession> GroupSessions { get; }
        DbSet<GroupSessionParticipant> GroupSessionParticipants { get; }
        DbSet<PaymentTransaction> PaymentTransactions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
