using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Directory;

public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _departmentRepository;

    DepartmentService(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Result<string>> GetWorkflowTitleAsync(int departmentId)
    {
        Result<IReadOnlyList<Department>> departmentResult =
            await _departmentRepository.GetAsync(c => c.Id == departmentId).ConfigureAwait(false);
        if (!departmentResult.IsSuccess)
        {
            return new Result<string>().AddError(departmentResult.GetErrorsString());
        }

        string workFlowApprovingTitle = departmentResult.Data[0].WorkFlowApprovingTitle;
        if (string.IsNullOrEmpty(workFlowApprovingTitle))
        {
            return new Result<string>().AddError("WorkFlow approving title is empty");
        }

        return new Result<string> { Data = workFlowApprovingTitle };
    }
}