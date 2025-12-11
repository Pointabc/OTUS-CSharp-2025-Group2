using Vacation.Core.Domain.Dto;
using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Factories;

public class RequestFactory
{
    public static Request CreateRequest(RequestCreateDto dto)
    {
        /*
         * processing
         */
        return new Request();
    }
}