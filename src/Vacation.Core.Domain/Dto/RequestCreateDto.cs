using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.ValueObjects;

namespace Vacation.Core.Domain.Dto;

public class RequestCreateDto
{
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
    public StatusOfRequest Status { get; set; }
    public TypeOfRequest Type { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateStop { get; set; }
    public string? Comment { get; set; }
}