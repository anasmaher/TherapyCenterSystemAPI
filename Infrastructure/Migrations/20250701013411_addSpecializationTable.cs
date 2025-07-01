using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSpecializationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specializations",
                table: "Therapists");

            migrationBuilder.CreateTable(
                name: "TherapistSpecializations",
                columns: table => new
                {
                    TherapistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistSpecializations", x => new { x.TherapistId, x.Name });
                    table.ForeignKey(
                        name: "FK_TherapistSpecializations_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TherapistSpecializations_Name",
                table: "TherapistSpecializations",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TherapistSpecializations");

            migrationBuilder.AddColumn<string>(
                name: "Specializations",
                table: "Therapists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
