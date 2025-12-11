using Vacation.Core.Domain.ValueObjects;

namespace Vacation.Core.Domain.Entities;

public class Request
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
    public readonly StatusOfRequest Status = StatusOfRequest.Draft;
    public TypeOfRequest Type { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateStop { get; set; }
    public string? Comment { get; set; }
}