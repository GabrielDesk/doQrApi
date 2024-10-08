using doQrApi.Entites;
using doQrApi.Objects.Enums;
using doQrApi.Objects.Request.EmployeeRequest;
using doQrApi.Repositories.EmployeeRepo;

namespace doQrApi.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee) 
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        
        public void DeleteEmployee(Guid Id)
        {
            _employeeRepository.DeleteEmployee(Id);
        }
        
        public void HandleStatusEmployee(Guid Id, EStatus Status)
        {
            _employeeRepository.HandleStatusEmployee(Id, Status);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public List<Employee>? GetEmployeeByName(GetEmployeeByNameRequest request)
        {
            return _employeeRepository.GetEmployeeByName(request);
        }
    }
}
