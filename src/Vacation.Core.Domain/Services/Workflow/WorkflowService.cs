using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Factories;
using Vacation.Core.Domain.Helpers;
using Vacation.Core.Domain.Services.Workflow.Steps;

namespace Vacation.Core.Domain.Services.Workflow;

public class MainWorkflowService : IWorkflowService
{
    private readonly IRepository<HistoryOfApprovingRequest> _repository;

    public MainWorkflowService(IRepository<HistoryOfApprovingRequest> repository)
    {
        _repository = repository;
    }

    public string GetTitle()
    {
        return "Main";
    }


    private Dictionary<string, string> scheme = new()
    {
        { "first", "sending_email_to_boss" },
        { "sending_email_to_boss", "approving_by_boss" },
        { "approving_by_boss", "approving_by_big_boss" }
    };

    public async Task<Result<bool>> RunAsync(Request request)
    {
        Result<IReadOnlyList<HistoryOfApprovingRequest>> historyResult =
            await _repository.GetAsync(c => c.RequestId == request.Id).ConfigureAwait(false);

        if (!historyResult.IsSuccess)
        {
            return new Result<bool>().AddError(historyResult.GetErrorsString());
        }

        string nextStep;
        var last = historyResult.Data.LastOrDefault();
        if (last == null)
        {
            nextStep = scheme["first"];
        }
        else
        {
            nextStep = scheme[last.WorkFlowStepTitle];
        }

        IWorkflowStep step = WorkflowStepFactory.Create(nextStep);
        Result<bool> stepResult = step.RunStep(request);
        if (!stepResult.IsSuccess)
        {
            return new Result<bool>().AddError(stepResult.GetErrorsString());
            ;
        }

        return stepResult;
    }

    public async Task<Result<bool>> SaveState(Request request, string stepTitle)
    {
        HistoryOfApprovingRequest history = HistoryOfApprovingFactory.Create(request, GetTitle(), stepTitle);
        var result = await _repository.SaveAsync(history).ConfigureAwait(false);
        return result.IsSuccess ? new Result<bool>() : new Result<bool>().AddError(result.GetErrorsString());
    }
}