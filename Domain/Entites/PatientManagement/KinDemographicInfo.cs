using Domain.Contracts;

namespace Domain.Entites.PatientManagement;

public class KinDemographicInfo:IBaseId,IBaseActionOn, IBaseActionBy
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    
    public string FamilyName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string RelationshipToPatient { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}