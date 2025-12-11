using Vacation.Core.Helpers;

namespace Vacation.Infrastructure.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<Result<TEntity>> SaveAsync(TEntity entity);
    Task<Result<TEntity>> DeleteAsync(TEntity entity);
    Task<Result<IReadOnlyList<TEntity>>> GetAsync(Predicate<TEntity> predicate);
}