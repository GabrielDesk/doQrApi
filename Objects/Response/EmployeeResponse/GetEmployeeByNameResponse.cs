using doQrApi.Entites;

namespace doQrApi.Objects.Response.EmployeeResponse
{
    public class GetEmployeeByNameResponse : BaseResponse
    {
       public List<Employee>? AllEmployees { get; set; }
    }
}
