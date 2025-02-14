using TodoCleanArchitecture.Application.Abstractions.Services;
using TodoCleanArchitecture.Domain.Abstractions.UnitOfWorks;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Application.Implementations.Services;

public class ManagerService : IManagerService
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<List<Manager>> GetAll()
    {
        return _unitOfWork.Manager.GetAll();
    }

    public async Task<Manager> Create(Manager request)
    {
        _unitOfWork.Manager.Add(request);
        await _unitOfWork.CommitAsync();
        return request;
    }
}
