using doQrApi.Data;
using doQrApi.Entites;
using doQrApi.Objects.Enums;
using doQrApi.Objects.Request.EmployeeRequest;
using System.Reflection;

namespace doQrApi.Repositories.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _database;

        public EmployeeRepository(ApplicationDbContext database) => _database = database;

        public void AddEmployee(Employee employee)
        {
            if (_database.TB_Employees.Any(e => e.EmployeeId == employee.EmployeeId ||
                                        e.CPF == employee.CPF ||
                                        e.Email == employee.Email ||
                                        e.Phone == employee.Phone))
            {
                throw new InvalidOperationException("Employee already exists");
            }

            _database.Add(employee);
            _database.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var dbUser = _database.TB_Employees.Find(employee.EmployeeId) ?? throw new InvalidOperationException("Employee non-existent");

            var properties = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            try
            {
                foreach (var property in properties)
                {
                    var dbValue = property.GetValue(dbUser);
                    var newValue = property.GetValue(employee);

                    if (!Equals(dbValue, newValue))
                    {
                        property.SetValue(dbUser, newValue);
                    }
                }

                _database.SaveChanges();
            }
            catch { throw new InvalidOperationException("It wass not possible to update employee"); }

        }

        public void HandleStatusEmployee(Guid EmployeeId, EStatus Status)
        {
            var employee = _database.TB_Employees.Find(EmployeeId);
            if (employee != null)
            {
                employee.Status = Status;
                _database.SaveChanges();
            }
            else throw new Exception("Non-existent employee.");
        }

        public void DeleteEmployee(Guid EmployeeId)
        {
            var employee = _database.TB_Employees.Find(EmployeeId);
            if (employee != null)
            {
                _database.Remove(employee);
                _database.SaveChanges();
            }
            else throw new Exception("Non-existent employee.");
        }

        public List<Employee> GetAllEmployees()
        {
            return [.. _database.TB_Employees];
        }

        public List<Employee>? GetEmployeeByName(GetEmployeeByNameRequest request)
        {
            return [.. _database.TB_Employees.Where(state => employee.Name.ToLower().Contains(request.Name.ToLower()))];
        }
    }
}
