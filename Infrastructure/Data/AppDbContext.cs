using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Therapist> Therapists => Set<Therapist>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<SessionNote> SessionNotes => Set<SessionNote>();
        public DbSet<TreatmentPlan> TreatmentPlans => Set<TreatmentPlan>();
        public DbSet<TreatmentPlanGoal> TreatmentPlanGoals => Set<TreatmentPlanGoal>();
        public DbSet<ExerciseTemplate> ExerciseTemplates => Set<ExerciseTemplate>();
        public DbSet<ExerciseSubmission> ExerciseSubmissions => Set<ExerciseSubmission>();
        public DbSet<GroupSession> GroupSessions => Set<GroupSession>();
        public DbSet<GroupSessionParticipant> GroupSessionParticipants => Set<GroupSessionParticipant>();
        public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
