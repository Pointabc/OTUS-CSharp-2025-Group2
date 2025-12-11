using Vacation.Core.Domain.Entities;
using Vacation.Core.Helpers;

namespace Vacation.Core.Domain.Services;

public interface IPolicyApplicatorService
{
    Task<Result<bool>> ApplyPoliciesAsync(Request request);
}