using System.Linq.Expressions;

namespace TodoCleanArchitecture.Domain.Abstractions.Repositories;

public interface IGenericRepository <TEntity> where TEntity : class
{
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    void Remove (TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

    Task<TEntity> GetById(object Id);
    Task<List<TEntity>> GetAll();
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity,bool>> predicate);
}
