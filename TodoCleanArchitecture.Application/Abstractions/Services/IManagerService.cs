using TodoCleanArchitecture.Application.DTOs.Common;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Application.Abstractions.Services;

public interface IManagerService
{
    Task<APIResponse> GetAll();
    Task<Manager> Create(Manager request);
}
