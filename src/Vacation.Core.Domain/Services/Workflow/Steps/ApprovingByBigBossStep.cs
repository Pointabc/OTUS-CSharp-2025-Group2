using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow.Steps;

public class ApprovingByBigBossStep : IWorkflowStep
{
    public string GetTitle()
    {
        return "approving_by_big_boss";
    }
    
    public Result<bool> RunStep(Request request)
    {
        return new Result<bool>(){Data = true};
    }
}