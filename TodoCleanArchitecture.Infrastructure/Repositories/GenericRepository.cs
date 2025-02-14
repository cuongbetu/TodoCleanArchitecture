using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoCleanArchitecture.Domain.Abstractions.Repositories;

namespace TodoCleanArchitecture.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ToDoCleanDbContext _dbContext;

    public GenericRepository(ToDoCleanDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate);
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public Task<T> GetById(object Id)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }
}
