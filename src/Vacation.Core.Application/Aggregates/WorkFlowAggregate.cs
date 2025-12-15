using Vacation.Core.Application.Factories;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;
using Vacation.Core.Domain.Services.Directory;
using Vacation.Core.Domain.Services.Workflow;

namespace Vacation.Core.Application.Aggregates;

public class WorkFlowAggregate : IWorkFlowAggregate
{
    private readonly IDepartmentService _departmentService;
    private readonly WorkflowFactory _workflowFactory;

    public WorkFlowAggregate(IDepartmentService departmentService,  WorkflowFactory workflowFactory)
    {
        _departmentService = departmentService;
        _workflowFactory = workflowFactory;
    }

    public async Task<Result<bool>> RunNextAsync(Request request)
    {
        Result<string> departmentResult =
            await _departmentService.GetWorkflowTitleAsync(request.DepartmentId).ConfigureAwait(false);

        if (!departmentResult.IsSuccess)
        {
            return new Result<bool>().AddError(departmentResult.GetErrorsString());
        }

        IWorkflowService workflowService = _workflowFactory.CreateWokflow(departmentResult.Data);
        Result<bool> workFlowResult = await workflowService.RunAsync(request).ConfigureAwait(false);
        if (!workFlowResult.IsSuccess)
        {
            return new Result<bool>().AddError(workFlowResult.GetErrorsString());
        }

        return new Result<bool>();
    }
}