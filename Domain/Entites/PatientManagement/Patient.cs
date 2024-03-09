using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entites.UserAccounts;

namespace Domain.Entites.PatientManagement;

public class Patient : IBaseId, IBaseActionOn, IBaseActionBy
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.Today;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }

    public string FamilyName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
        set
        {
            var parts = value.Split(' ');
            if (parts.Length == 2)
            {
                FirstName = parts[0];
                LastName = parts[1];
            }
            else
            {
                FirstName = value;
                LastName = string.Empty;
            }
        }
    }
    [Required] public DateOnly DateOfBirth { get; set; }
    [Required] public string Gender { get; set; }
    [Required] public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string PatientType { get; set; } 
    public string PatientStatus { get; set; }
    public string Ppsn { get; set; }
    public string IhINumber { get; set; }
    public string Title { get; set; } //(e.g. Dr or Mr or Ms, etc.)
    [Required] public string Mobile { get; set; }
    [Required] public string EmailAddress { get; set; }
    public string HomePhone { get; set; }
    public string UniqueNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
 

    #region Master Card Details

    public string GmsNumber { get; set; }
    public string GmsDoctorNumber { get; set; }
    public string GmsDispensingStatus { get; set; }
    public DateTime GmsReviewDate { get; set; }

    #endregion

    #region Doctor Visit Card Details

    public string DvNumber { get; set; }
    public string DvDoctorNumber { get; set; }
    public DateTime DvReviewDate { get; set; }
    public string DvDistanceCode { get; set; }

    #endregion

    #region Drug Payment Scheme details

    public string DpsNumber { get; set; }
    public DateOnly Expiry { get; set; }

    #endregion

    #region Private Health Insurance Details
    public string InsuranceCompany { get; set; }
    public string InsuranceMembershipNumber { get; set; }
    public string InsuranceCoverType { get; set; }
    public string PolicyNumber { get; set; }
    #endregion

    public string CompanyMedicalScheme { get; set; }
    public string PersonalPublicServiceNumber { get; set; }
    public string Occupation { get; set; }
    public string MaritalStatus { get; set; }
    public string Religion { get; set; }
    public string Ethnicity { get; set; }
    public string PreferredLanguage { get; set; }
    public string InterpreterRequired { get; set; }
    public string TransportNeeds { get; set; }
    public string AdvocacyNeeds { get; set; }
    public DateTime RegistrationWithPractice { get; set; }
    public DateTime DeregistrationWithPractice { get; set; }
    public string ReasonOfDeregistration { get; set; }
    public string EnrollmentWithPrimaryCareTeam { get; set; }
    public DateTime DateOfEnrollmentWithPrimaryCareTeam { get; set; }
    public DateTime DateOfDeath { get; set; }
    public string CauseOfDeath { get; set; }
}