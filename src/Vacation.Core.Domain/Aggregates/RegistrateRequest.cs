using Vacation.Core.Domain.Dto;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Factories;
using Vacation.Core.Domain.Services;
using Vacation.Core.Helpers;
using Vacation.Infrastructure.Repositories;

namespace Vacation.Core.Domain.Aggregates;

public class RegistrateRequest : IRequestRegistrator
{
    private readonly IRepository<Request> _requestRepository;
    private readonly IPolicyApplicatorService _policyApplicatorService;

    public RegistrateRequest(IRepository<Request> requestRepository, IPolicyApplicatorService policyApplicatorService)
    {
        _requestRepository = requestRepository;
        _policyApplicatorService = policyApplicatorService;
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
            
            /**
             * всякие уведомления 
             */
            
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

        return result;
    }
}