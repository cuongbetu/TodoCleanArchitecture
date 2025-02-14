using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Application.Abstractions.Services;

public interface IManagerService
{
    Task<List<Manager>> GetAll();
    Task<Manager> Create(Manager request);
}
