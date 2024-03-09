using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredByDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormerFamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersMaidenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EriCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmsDoctorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmsDispensingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmsReviewDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DvNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvDoctorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DvReviewDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DvDistanceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DpsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiry = table.Column<DateOnly>(type: "date", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyMedicalScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalPublicServiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IhINumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterpreterRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportNeeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvocacyNeeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationWithPractice = table.Column<DateOnly>(type: "date", nullable: false),
                    DeregistrationWithPractice = table.Column<DateOnly>(type: "date", nullable: false),
                    ReasonOfDeregistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentWithPrimaryCareTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfEnrollmentWithPrimaryCareTeam = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfDeath = table.Column<DateOnly>(type: "date", nullable: false),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
