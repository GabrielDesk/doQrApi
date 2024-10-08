using doQrApi.Entites;
using doQrApi.Objects.Enums;
using doQrApi.Objects.Request.EmployeeRequest;

namespace doQrApi.Repositories.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Guid EmployeeId);
        void HandleStatusEmployee(Guid EmployeeId, EStatus Status); 
        List<Employee>? GetAllEmployees();
        List<Employee>? GetEmployeeByName(GetEmployeeByNameRequest request);

    }
}
