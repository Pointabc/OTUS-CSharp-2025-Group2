using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Factories;

public class HistoryOfApprovingFactory
{
    public static HistoryOfApprovingRequest Create(Request request, string workflowTitle, string workflowStep)
    {
        return new HistoryOfApprovingRequest()
        {
            RequestId = request.Id,
            WorkFlowStepTitle = workflowStep,
            WorkFlowTitle = workflowTitle
        };
    }
}