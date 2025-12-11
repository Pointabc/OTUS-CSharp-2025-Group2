using Vacation.Core.Domain.Dto;
using Vacation.Core.Helpers;

namespace Vacation.Core.Domain.Aggregates;

public interface IRequestRegistrator
{
    Task<Result<bool>> RegistrateRequestAsync(int requestId);
    Task<Result<bool>> SaveRequestAsync(RequestCreateDto dto);
}