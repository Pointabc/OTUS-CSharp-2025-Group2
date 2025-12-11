using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Services.Policies;

public class BasePolicyService : IPolicyService
{
    protected readonly Policy Policy;
    public BasePolicyService(Policy policy)
    {
        Policy = policy;
    }
    public bool Apply(Request request)
    {
        //это хардкод, просто для ясности
        if (Policy.DepartmentId == 1 && request.DateStart.Month == 12 &&  request.DateStart.Day >= 14)
        {
            return false;
        }
        return true;
    }
}