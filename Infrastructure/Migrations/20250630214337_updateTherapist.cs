using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTherapist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlanGoal_TreatmentPlans_TreatmentPlanId",
                table: "TreatmentPlanGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatmentPlanGoal",
                table: "TreatmentPlanGoal");

            migrationBuilder.RenameTable(
                name: "TreatmentPlanGoal",
                newName: "TreatmentPlanGoals");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentPlanGoal_TreatmentPlanId",
                table: "TreatmentPlanGoals",
                newName: "IX_TreatmentPlanGoals_TreatmentPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatmentPlanGoals",
                table: "TreatmentPlanGoals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlanGoals_TreatmentPlans_TreatmentPlanId",
                table: "TreatmentPlanGoals",
                column: "TreatmentPlanId",
                principalTable: "TreatmentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlanGoals_TreatmentPlans_TreatmentPlanId",
                table: "TreatmentPlanGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatmentPlanGoals",
                table: "TreatmentPlanGoals");

            migrationBuilder.RenameTable(
                name: "TreatmentPlanGoals",
                newName: "TreatmentPlanGoal");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentPlanGoals_TreatmentPlanId",
                table: "TreatmentPlanGoal",
                newName: "IX_TreatmentPlanGoal_TreatmentPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatmentPlanGoal",
                table: "TreatmentPlanGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlanGoal_TreatmentPlans_TreatmentPlanId",
                table: "TreatmentPlanGoal",
                column: "TreatmentPlanId",
                principalTable: "TreatmentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
