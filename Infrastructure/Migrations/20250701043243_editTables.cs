using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TherapistSpecializations_Therapists_TherapistId",
                table: "TherapistSpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapistSpecializations",
                table: "TherapistSpecializations");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "TreatmentPlans");

            migrationBuilder.RenameTable(
                name: "TherapistSpecializations",
                newName: "TherapistSpecialization");

            migrationBuilder.RenameIndex(
                name: "IX_TherapistSpecializations_Name",
                table: "TherapistSpecialization",
                newName: "IX_TherapistSpecialization_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapistSpecialization",
                table: "TherapistSpecialization",
                columns: new[] { "TherapistId", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistSpecialization_Therapists_TherapistId",
                table: "TherapistSpecialization",
                column: "TherapistId",
                principalTable: "Therapists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TherapistSpecialization_Therapists_TherapistId",
                table: "TherapistSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapistSpecialization",
                table: "TherapistSpecialization");

            migrationBuilder.RenameTable(
                name: "TherapistSpecialization",
                newName: "TherapistSpecializations");

            migrationBuilder.RenameIndex(
                name: "IX_TherapistSpecialization_Name",
                table: "TherapistSpecializations",
                newName: "IX_TherapistSpecializations_Name");

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "TreatmentPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapistSpecializations",
                table: "TherapistSpecializations",
                columns: new[] { "TherapistId", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistSpecializations_Therapists_TherapistId",
                table: "TherapistSpecializations",
                column: "TherapistId",
                principalTable: "Therapists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
