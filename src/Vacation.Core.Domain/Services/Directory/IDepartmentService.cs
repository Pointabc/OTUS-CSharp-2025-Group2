using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Directory;

public interface IDepartmentService
{
    Task<Result<string>> GetWorkflowTitleAsync(int departmentId); 
}