using employee_operation.Dto;
using employee_operation.Services;
using Microsoft.AspNetCore.Mvc;

namespace employee_operation.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase // Inherit from ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    public IActionResult GetEmployee()
    {
        return Ok(_employeeService.GetAllEmployees());
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody] EmployeeRequestDto employee)
    {
        return Ok(_employeeService.AddEmployee(employee));
    }
    
    [HttpPut("{employeeId}")]
    public IActionResult UpdateEmployee([FromBody] EmployeUpdateRequestDto employee, int employeeId)
    {
        return Ok(_employeeService.UpdateEmployee(employee, employeeId));
    }
    
    [HttpDelete("{employeeId}")]
    public IActionResult DeleteEmployee(int employeeId)
    {
        _employeeService.DeleteEmployee(employeeId);
        return Ok();
    }
}