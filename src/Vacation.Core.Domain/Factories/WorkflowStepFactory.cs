using Vacation.Core.Domain.Services.Workflow.Steps;

namespace Vacation.Core.Domain.Factories;

public class WorkflowStepFactory
{
    public static IWorkflowStep Create(string title)
    {
        switch (title)
        {
            case "sending_email_to_boss":
                return new SendingEmailToBossStep();
            case "approving_big_boss":
                return new ApprovingByBossStep();
            case "approving_by_big_boss":
                return new ApprovingByBigBossStep();
            default:
                throw new ArgumentOutOfRangeException(nameof(title), title, null);
        }
    }
}