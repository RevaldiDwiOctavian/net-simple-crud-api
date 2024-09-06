using employee_operation.Dto;

namespace employee_operation.Services;

public interface IEmployeeService
{
    EmployeeResponseDto AddEmployee(EmployeeRequestDto dto);
    List<EmployeeResponseDto> GetAllEmployees();
    EmployeeResponseDto UpdateEmployee(EmployeUpdateRequestDto dto, int employeeId);
    void DeleteEmployee(int employeeId);
}