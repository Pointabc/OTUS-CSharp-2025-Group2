using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Services.Policies;

public interface IPolicyService
{
    bool Apply(Request request);
}