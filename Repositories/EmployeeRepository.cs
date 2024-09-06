using employee_operation.Entities;
using Microsoft.Extensions.Logging;

namespace employee_operation.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(ILogger<EmployeeRepository> logger)
        {
            _employees = new List<Employee>
            {
                
            };
            _logger = logger;
        }

        public Employee AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            _logger.LogInformation("Employee {EmployeeId} added successfully.", employee.EmployeeId);
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            _logger.LogInformation("Retrieving all employees.");
            return _employees;
        }

        public bool CheckExistingEmployee(int employeeId)
        {
            var employee = _employees.Find(e => e.EmployeeId == employeeId);

            if (employee == null)
            {
                return false;
            }
            
            return true;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                _logger.LogWarning("Employee with ID {EmployeeId} not found.", employeeId);
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");
            }

            _logger.LogInformation("Employee {EmployeeId} retrieved.", employee.EmployeeId);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.EmployeeId);
            existingEmployee.FullName = employee.FullName;
            existingEmployee.BirthDate = employee.BirthDate;

            _logger.LogInformation("Employee {EmployeeId} updated successfully.", employee.EmployeeId);
            return existingEmployee;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            _employees.Remove(employee);
            _logger.LogInformation("Employee {EmployeeId} deleted.", employeeId);
        }
    }
}
