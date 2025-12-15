using Vacation.Core.Application.Dto;
using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Application.Factories;

public class RequestFactory
{
    public static Request CreateRequest(RequestCreateDto dto)
    {
        return new Request();
    }
}