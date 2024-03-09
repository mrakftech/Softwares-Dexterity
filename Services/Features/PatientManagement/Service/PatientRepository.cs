using System.Collections.ObjectModel;
using AutoMapper;
using Database;
using Domain.Entites.PatientManagement;
using Features.Contracts.Modules;
using Features.Respository;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Patient;
using Shared.Responses.Patient;
using Shared.State;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PatientRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ObservableCollection<PatientListResponse>> GetPatients()
    {
        var patients = await _context.Patients.Where(x => x.IsDeleted == false).ToListAsync();
        return _mapper.Map<ObservableCollection<PatientListResponse>>(patients);
    }

    public async Task<PatientResponse> GetPatient(Guid id)
    {
        var patientInDb = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        var data = _mapper.Map<PatientResponse>(patientInDb);
        return data;
    }

    public async Task<IResult> CreatePatient(PatientRequest request, CancellationToken cancellationToken)
    {
        try
        {
            request.CreatedBy = ApplicationState.CurrentUser.UserId;
            var patient = _mapper.Map<Patient>(request);
            await _context.Patients.AddAsync(patient, cancellationToken);
            var rowsUpdated = await _context.SaveChangesAsync(cancellationToken);
            if (rowsUpdated > 0)
            {
                return await Result.SuccessAsync("Patient has been saved.");
            }

            return await Result.FailAsync("Failed to save patient.");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeletePatient(Guid id)
    {
        var patientInDb = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        if (patientInDb is not null)
        {
            patientInDb.IsDeleted = true;
        }

        return await Result.SuccessAsync("Patient has been deleted");
    }
}