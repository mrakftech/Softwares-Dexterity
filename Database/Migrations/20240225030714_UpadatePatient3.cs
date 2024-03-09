using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpadatePatient3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BirthSurname",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EriCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FormerFamilyName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "MothersMaidenName",
                table: "Patients",
                newName: "UniqueNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniqueNumber",
                table: "Patients",
                newName: "MothersMaidenName");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthSurname",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EriCode",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormerFamilyName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
