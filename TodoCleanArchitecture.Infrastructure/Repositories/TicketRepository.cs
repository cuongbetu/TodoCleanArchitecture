using TodoCleanArchitecture.Domain.Abstractions.Repositories;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Infrastructure.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    private readonly ToDoCleanDbContext _dbContext;

    public TicketRepository(ToDoCleanDbContext dbContext): base (dbContext)
    {
        _dbContext = dbContext;
    }
}
