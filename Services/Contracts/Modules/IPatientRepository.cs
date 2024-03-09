using System.Collections.ObjectModel;
using Domain.Entites.PatientManagement;
using Features.Contracts.Repositroy;
using Shared.Dtos.Patient;
using Shared.Responses.Patient;
using Shared.Wrapper;

namespace Features.Contracts.Modules;

public interface IPatientRepository : IRepositoryBase<Patient>
{
    public Task<ObservableCollection<PatientListResponse>> GetPatients();

    public Task<PatientResponse> GetPatient(Guid id);
    public Task<IResult> CreatePatient(PatientRequest request, CancellationToken cancellationToken);
    public Task<IResult> DeletePatient(Guid id);
}