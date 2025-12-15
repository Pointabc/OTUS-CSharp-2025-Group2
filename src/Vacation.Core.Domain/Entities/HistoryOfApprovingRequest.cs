namespace Vacation.Core.Domain.Entities;

public class HistoryOfApprovingRequest
{
    public int RequestId { get; set; }
    public string WorkFlowTitle { get; set; }
    public string WorkFlowStepTitle { get; set; }
}