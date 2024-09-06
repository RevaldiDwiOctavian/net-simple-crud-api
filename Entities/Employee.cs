namespace employee_operation.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    
    public required string FullName { get; set; }
    
    public DateOnly BirthDate { get; set; }
}