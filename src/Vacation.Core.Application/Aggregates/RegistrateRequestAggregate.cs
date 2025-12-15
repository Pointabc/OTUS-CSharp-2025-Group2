using Vacation.Core.Application.Dto;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Application.Factories;
using Vacation.Core.Domain.Services;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Application.Aggregates;

public class RegistrateRequestAggregate : IRequestRegistratorAggregate
{
    private readonly IRepository<Request> _requestRepository;
    private readonly IPolicyApplicatorService _policyApplicatorService;
    private readonly IWorkFlowAggregate _workFlowAggregate;

    public RegistrateRequestAggregate(IRepository<Request> requestRepository,
        IPolicyApplicatorService policyApplicatorService, IWorkFlowAggregate workFlowAggregate)
    {
        _requestRepository = requestRepository;
        _policyApplicatorService = policyApplicatorService;
        _workFlowAggregate = workFlowAggregate;
    }

    public async Task<Result<bool>> RegistrateRequestAsync(int requestId)
    {
        Result<bool> result = new();

        Result<IReadOnlyList<Request>> getRequestResult =
            await _requestRepository.GetAsync(c => c.Id == requestId).ConfigureAwait(false);
        if (!getRequestResult.IsSuccess)
        {
            return result.AddError(getRequestResult.GetErrorsString());
        }

        if (getRequestResult.Data[0] is Request request)
        {
            Result<bool> policyResult =
                await _policyApplicatorService.ApplyPoliciesAsync(request).ConfigureAwait(false);

            if (!policyResult.IsSuccess)
            {
                return result.AddError(policyResult.GetErrorsString());
            }

            if (!policyResult.Data)
            {
                return result.AddError("the request is rejected");
            }

            return result;
        }

        return result.AddError("the request isn't found");
    }

    public async Task<Result<bool>> SaveRequestAsync(RequestCreateDto dto)
    {
        Result<bool> result = new();
        Request request = RequestFactory.CreateRequest(dto);
        Result<Request> saveResult = await _requestRepository.SaveAsync(request).ConfigureAwait(false);
        if (!saveResult.IsSuccess)
        {
            return result.AddError(saveResult.GetErrorsString());
        }

        Result<bool> workFlowResult = await _workFlowAggregate.RunNextAsync(request).ConfigureAwait(false);
        if (!workFlowResult.IsSuccess)
        {
            return result.AddError(saveResult.GetErrorsString());
        }

        return result;
    }
}