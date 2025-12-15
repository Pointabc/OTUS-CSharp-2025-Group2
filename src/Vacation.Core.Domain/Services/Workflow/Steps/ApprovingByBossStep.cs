using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow.Steps;

public class ApprovingByBossStep : IWorkflowStep
{
    public string GetTitle()
    {
        return "approving_by_boss";
    }
    
    public Result<bool> RunStep(Request request)
    {
        return new Result<bool>(){Data = true};
    }
}