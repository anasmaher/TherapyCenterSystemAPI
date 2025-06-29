using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GroupSessionParticipants_GroupSessionId_PatientId",
                table: "GroupSessionParticipants",
                columns: new[] { "GroupSessionId", "PatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_PatientId_TherapistId",
                table: "TreatmentPlans",
                columns: new[] { "PatientId", "TherapistId" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId_TherapistId_StartTime",
                table: "Appointments",
                columns: new[] { "PatientId", "TherapistId", "Date" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
