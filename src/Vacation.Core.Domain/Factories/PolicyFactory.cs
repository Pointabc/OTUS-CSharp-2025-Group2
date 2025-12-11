using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Services.Policies;

namespace Vacation.Core.Domain.Factories;

public class PolicyFactory
{
    public static IPolicyService CreatePolicy(Policy policy)
    {
        IPolicyService? policyService;

        switch (policy.Code)
        {
            case "beforeNYDeny":
                policyService = new BeforeNYDenyPolicyService(policy);
                break;
            default:
                throw new InvalidOperationException($"code {policy.Code} not supported");
        }

        return policyService;
    }
}