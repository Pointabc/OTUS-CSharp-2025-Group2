using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Services.Policies;

public class BasePolicyService
{
    protected readonly Policy Policy;
    public BasePolicyService(Policy policy)
    {
        Policy = policy;
    }
}