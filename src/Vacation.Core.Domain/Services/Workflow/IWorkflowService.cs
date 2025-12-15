using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow;

public interface IWorkflowService
{
    string GetTitle();
    Task<Result<bool>> RunAsync(Request request);
    Task<Result<bool>> SaveState(Request request, string stepTitle);
}