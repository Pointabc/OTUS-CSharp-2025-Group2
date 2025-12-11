using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Factories;
using Vacation.Core.Domain.Services.Policies;
using Vacation.Core.Helpers;
using Vacation.Infrastructure.Repositories;

namespace Vacation.Core.Domain.Services;

public class PolicyApplicatorService : IPolicyApplicatorService
{
    private readonly IRepository<Policy> _policyRepository;

    public PolicyApplicatorService(IRepository<Policy> policyRepository)
    {
        _policyRepository = policyRepository;
    }

    public async Task<Result<bool>> ApplyPoliciesAsync(Request request)
    {
        Result<bool> result = new();

        Result<IReadOnlyList<Policy>> getPolicyResult =
            await _policyRepository.GetAsync(c => c.DepartmentId == request.DepartmentId).ConfigureAwait(false);

        if (!getPolicyResult.IsSuccess)
        {
            return new Result<bool>().AddError(getPolicyResult.GetErrorsString());
        }

        bool isSucess = false;
        foreach (var policy in getPolicyResult.Data)
        {
            IPolicyService policyService = PolicyFactory.CreatePolicy(policy);
            isSucess &= policyService.Apply(request);
        }

        result.Data = isSucess;
        return result;
    }
}