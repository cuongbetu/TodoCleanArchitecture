using TodoCleanArchitecture.Domain.Abstractions.Repositories;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Infrastructure.Repositories;

public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
{
    private readonly ToDoCleanDbContext _dbContext;

    public ManagerRepository(ToDoCleanDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
