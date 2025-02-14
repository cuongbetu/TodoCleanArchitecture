using TodoCleanArchitecture.Domain.Abstractions.Repositories;

namespace TodoCleanArchitecture.Domain.Abstractions.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IManagerRepository Manager { get; }
    IMemberRepository Member {  get; }
    ITicketRepository Ticket { get; }
    Task CommitAsync();
}
