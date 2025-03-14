using Microsoft.EntityFrameworkCore;
using TodoCleanArchitecture.Application.Abstractions.Services;
using TodoCleanArchitecture.Application.DTOs.Common;
using TodoCleanArchitecture.Application.DTOs.Manager;
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

    public async Task<APIResponse> GetAll()
    {
        var result = await _unitOfWork.Manager.FindByCondition(x => x.Id != 0)
                                    .Select(x => new ManagerDTO
                                    {
                                        ManagerName = x.ManagerName
                                    }).ToListAsync();
       
        if (result.Count <= 0)
        {
            return APIResponse.BadRequest("Result not found");
        }

        return APIResponse.Success(result);
    }

    public async Task<Manager> Create(Manager request)
    {
        _unitOfWork.Manager.Add(request);
        await _unitOfWork.CommitAsync();
        return request;
    }
}
