namespace Vacation.Core.Domain.Entities;

public class Employee
{
    public int Id  { get; set; }
    public string FirstName { get; set; }
    public string LastName  { get; set; }
    public DateTime DateBirthday  { get; set; }
    public int RemainedDaysOfVacatiion  { get; set; }
}