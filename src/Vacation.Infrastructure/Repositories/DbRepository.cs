using Vacation.Core.Domain.Services;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Infrastructure.Repositories;

public class DbRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public Task<Result<TEntity>> SaveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TEntity>> DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IReadOnlyList<TEntity>>> GetAsync(Predicate<TEntity> predicate)
    {
        throw new NotImplementedException();
    }
}