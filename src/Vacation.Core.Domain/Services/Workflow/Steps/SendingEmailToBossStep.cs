using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow.Steps;

public class SendingEmailToBossStep : IWorkflowStep
{
    public string GetTitle()
    {
        return "sending_email_to_boss";
    }
    
    public Result<bool> RunStep(Request request)
    {
        /**
         * отслыка email непосредственному начальнику
         */
        return new Result<bool>(){Data = true};
    }
}