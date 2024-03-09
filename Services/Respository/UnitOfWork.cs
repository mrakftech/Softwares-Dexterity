using AutoMapper;
using Database;
using Features.Contracts.Modules;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Services.Features.UserAccounts.Service;

namespace Features.Respository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private IUserRepository _user;
    private IPatientRepository _patient;

    public UnitOfWork(ApplicationDbContext context, IUserRepository user, IMapper mapper, IPatientRepository patient)
    {
        _context = context;
        _user = user;
        _mapper = mapper;
        _patient = patient;
    }

    public IUserRepository User
    {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(_context, _mapper);
            }

            return _user;
        }
    }

    public IPatientRepository Patient
    {
        get
        {
            if (_patient == null)
            {
                _user = new UserRepository(_context, _mapper);
            }

            return _patient;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}