using System.ComponentModel.DataAnnotations;

namespace employee_operation.Dto;

public class EmployeUpdateRequestDto
{
    [Required(ErrorMessage = "FullName is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "FullName must be between 1 and 100 characters.")]
    public required string FullName { get; set; }
    
    [Required(ErrorMessage = "BirthDate is required.")]
    public required string BirthDate { get; set; }
}