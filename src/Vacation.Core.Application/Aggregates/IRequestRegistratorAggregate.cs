using Vacation.Core.Application.Dto;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Application.Aggregates;

public interface IRequestRegistratorAggregate
{
    Task<Result<bool>> RegistrateRequestAsync(int requestId);
    Task<Result<bool>> SaveRequestAsync(RequestCreateDto dto);
}