using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SessionNote> SessionNotes { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<ExerciseTemplate> ExerciseTemplates { get; set; }
        public DbSet<ExerciseSubmission> ExerciseSubmissions { get; set; }
        public DbSet<GroupSession> GroupSessions { get; set; }
        public DbSet<GroupSessionParticipant> GroupSessionParticipants { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
