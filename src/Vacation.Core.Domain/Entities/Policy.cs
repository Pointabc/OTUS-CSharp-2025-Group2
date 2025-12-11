namespace Vacation.Core.Domain.Entities;

public class Policy
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string Code { get; set; }
    public short Sort { get; set; }
}