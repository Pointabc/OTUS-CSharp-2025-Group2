using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow.Steps;

public interface IWorkflowStep
{
    string GetTitle();
    Result<bool> RunStep(Request request);
}