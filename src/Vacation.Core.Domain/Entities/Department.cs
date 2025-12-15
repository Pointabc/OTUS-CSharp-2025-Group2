namespace Vacation.Core.Domain.Entities;

public class Department
{
    public int Id  { get; set; }
    public string Title  { get; set; }
    public int ParentId  { get; set; }
    public string WorkFlowApprovingTitle { get; set; }
}