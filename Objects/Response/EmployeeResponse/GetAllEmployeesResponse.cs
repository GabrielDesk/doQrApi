using doQrApi.Entites;

namespace doQrApi.Objects.Response.EmployeeResponse
{
    public class GetAllEmployeesResponse : BaseResponse
    {
       public List<Employee>? AllEmployees { get; set; }
    }
}
