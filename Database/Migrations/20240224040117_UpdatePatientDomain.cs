using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisteredByDoctorId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "MembershipNumber",
                table: "Patients",
                newName: "InsuranceMembershipNumber");

            migrationBuilder.RenameColumn(
                name: "CoverType",
                table: "Patients",
                newName: "InsuranceCoverType");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Patients",
                newName: "InsuranceCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsuranceMembershipNumber",
                table: "Patients",
                newName: "MembershipNumber");

            migrationBuilder.RenameColumn(
                name: "InsuranceCoverType",
                table: "Patients",
                newName: "CoverType");

            migrationBuilder.RenameColumn(
                name: "InsuranceCompany",
                table: "Patients",
                newName: "Company");

            migrationBuilder.AddColumn<Guid>(
                name: "RegisteredByDoctorId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
