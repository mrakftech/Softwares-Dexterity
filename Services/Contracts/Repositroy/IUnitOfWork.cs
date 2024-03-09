using Features.Contracts.Modules;

namespace Services.Contracts.Repositroy;

public interface IUnitOfWork
{
    IUserRepository User { get; }
    IPatientRepository Patient { get; }
    void Save();
}