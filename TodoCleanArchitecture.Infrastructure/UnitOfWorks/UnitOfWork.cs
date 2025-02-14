using TodoCleanArchitecture.Domain.Abstractions.Repositories;
using TodoCleanArchitecture.Domain.Abstractions.UnitOfWorks;
using TodoCleanArchitecture.Infrastructure.Repositories;

namespace TodoCleanArchitecture.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ToDoCleanDbContext _dbContext;
    private IMemberRepository _memberRepository;
    private ITicketRepository _ticketRepository;
    private IManagerRepository _managerRepository;

    public UnitOfWork(ToDoCleanDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IManagerRepository Manager
    {
        get
        {
            if (_managerRepository is null)
            {
                _managerRepository = new ManagerRepository(_dbContext);
            }
            return _managerRepository;
        }
    }

    public IMemberRepository Member
    {
        get
        {
            if (_memberRepository is null)
            {
                _memberRepository = new MemberRepository(_dbContext);
            }
            return _memberRepository;
        }
    }

    public ITicketRepository Ticket
    {
        get
        {
            if (_ticketRepository is null)
            {
                _ticketRepository = new TicketRepository(_dbContext);
            }
            return _ticketRepository;
        }
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
