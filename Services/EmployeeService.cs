using employee_operation.Dto;
using employee_operation.Entities;
using employee_operation.Repositories;

namespace employee_operation.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Add a new employee
        public EmployeeResponseDto AddEmployee(EmployeeRequestDto dto)
        {
            if (_employeeRepository.CheckExistingEmployee(dto.EmployeeId))
            {
                throw new Exception("Employee already exists");
            }

            Employee employee;

            try
            {
                employee = new Employee
                {
                    EmployeeId = dto.EmployeeId,
                    FullName = dto.FullName,
                    BirthDate = DateOnly.ParseExact(dto.BirthDate, "dd-MM-yyyy"),
                };
            }
            catch (Exception e)
            {
                throw new ArgumentException($"The BirthDate provided is not in a valid format. Please use dd-MM-yyyy instead.");
            }
            return ConvertToResponseDto(_employeeRepository.AddEmployee(employee));
        }

        // Get all employees
        public List<EmployeeResponseDto> GetAllEmployees()
        {
            List<Employee> employees = _employeeRepository.GetAllEmployees();
            List<EmployeeResponseDto> employeesRes = employees
                .Select(employee => ConvertToResponseDto(employee))
                .ToList();
    
            return employeesRes;
        }

        // Get an employee by ID
        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeRepository.GetEmployeeById(employeeId);
        }

        // Update an employee and return the updated employee
        public EmployeeResponseDto UpdateEmployee(EmployeUpdateRequestDto dto, int employeeId)
        {
            Employee employee;

            try
            {
                employee = _employeeRepository.GetEmployeeById(employeeId);
                employee.FullName = dto.FullName;
                employee.BirthDate = DateOnly.ParseExact(dto.BirthDate, "dd-MM-yyyy");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"The BirthDate provided is not in a valid format. Please use dd-MM-yyyy instead.");
            }
            
            return ConvertToResponseDto(_employeeRepository.UpdateEmployee(employee));
        }

        // Delete an employee
        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.DeleteEmployee(employeeId);
        }

        private EmployeeResponseDto ConvertToResponseDto(Employee employee)
        {
            return new EmployeeResponseDto
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                BirthDate = employee.BirthDate.ToString("dd-MMM-yyyy") // Format to "01-Oct-2000"
            };
        }
    }
}