using TodoCleanArchitecture.Domain.Abstractions.Repositories;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Infrastructure.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    private readonly ToDoCleanDbContext _dbContext;

    public MemberRepository(ToDoCleanDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
