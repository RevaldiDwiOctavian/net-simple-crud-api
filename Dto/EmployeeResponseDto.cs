namespace employee_operation.Dto;

public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }
    
    public required string FullName { get; set; }
    
    public required string BirthDate { get; set; }
}