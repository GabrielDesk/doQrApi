using doQrApi.Entites;
using doQrApi.Objects.Enums;
using doQrApi.Objects.Errors;
using doQrApi.Objects.Request.EmployeeRequest;
using doQrApi.Objects.Response;
using doQrApi.Objects.Response.EmployeeResponse;
using doQrApi.Objects.Response.Messages;
using doQrApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
 
namespace doQrApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService) => _employeeService = employeeService;

        // GET: api/<EmployeeController>/GetAllEmployees
        // POST api/todo
        /// <summary>
        /// Busca todos os funcionários cadastrados.
        /// </summary>
        /// <returns>Todos os funcionários cadastrados</returns>
        /// <response code="200">Retorna a lista de todos os funcionários cadastrados</response>
        /// <response code="400">Se a lista estiver vazia</response> 
        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            GetAllEmployeesResponse response = new();
            //IEnumerable<string> headerValues = null;
            //try { headerValues = Request.Headers.GetValues("Token"); }
            //catch { response.Erro = "Strings.Invalid_Token_Message"; response.ErrorId = 1; if (!dev) { return Ok(response); } }

            try
            {
                List<Employee> allEmployees = _employeeService.GetAllEmployees();

                response.AllEmployees = allEmployees;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.ErrorId = ErrorCodes.GeneralErrorFetchingAllEmployees;
                response.Error = ex.ToString();
                response.Message = ResponseMessages.GeneralOperationFailed;

                throw new Exception("Error", ex);
            }

            return Ok(response);
        }

        // POST api/<EmployeeController>/GetEmployeeByName
        /// <summary>
        /// Busca o(s) funcionário(s) pelo nome.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Uma lista usuário a partir do nome buscado</returns>
        /// <remarks>
        /// Sample request
        ///     POST/GetEmployeeByName
        ///     {
        ///         "name": Ronaldo Ferreira Martins
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o(s) funcionário(s)</response>
        /// <response code="400">Se não existir funcionário(s) com o nome atribuido ao parâmetro</response> 
        [HttpPost("GetEmployeeByName")]
        public IActionResult GetEmployeeByName(GetEmployeeByNameRequest request)
        {
            GetEmployeeByNameResponse response = new();

            try
            {
                List<Employee>? employee = _employeeService.GetEmployeeByName(request);

                response.AllEmployees = employee;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorId = ErrorCodes.GeneralErrorFetchingEmployeeByName;
                response.Error = ex.ToString();
                response.Message = ResponseMessages.GeneralOperationFailed;

                return BadRequest(response);
                throw new Exception("Error", ex);
            }

            return Ok(response);
        }

        // POST api/<EmployeeController>/AddEmployee
        /// <summary>
        /// Adiciona o funcionário ao banco de dados.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Sucesso</returns>
        /// <remarks>
        /// Sample request
        ///     POST/AddEmployee
        ///     {
        ///          "name": Ronaldo Ferreira Martins
        ///          "email": "ronaldo.martins@EEexample.com",
        ///          "CPF": "12345678901",
        ///          "phone": "5512987654321",
        ///          "birthDate": "1985-04-20",
        ///          "employeeContractType": 1,
        ///          "status": 1
        ///     }
        /// </remarks>
        /// <response code="200">Retorna sucesso ao criar funcionário</response>
        /// <response code="400">Se não for possível adicionar funcionário</response> 
        [HttpPost("AddEmployee")]
        [SwaggerOperation(Summary = "Add a new employee")]
        public IActionResult AddEmployee(Employee request)
        {
            BaseResponse response = new();

            try
            {
                _employeeService.AddEmployee(request);

                response.Message = "Operação concluída com sucesso, funcionário adicionado.";
                response.Success = true;
            }
            catch (InvalidOperationException ex)
            {
                response.ErrorId = ErrorCodes.EmployeeAlreadyExists;
                response.Error = ex.Message;
                response.Message = ResponseMessages.EmployeeAlreadyExists;

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.ErrorId = ErrorCodes.GeneralErrorAddingEmployee;
                response.Error = ex.Message;
                response.Message = ResponseMessages.GeneralOperationFailed;

                return BadRequest(response);
            }

            return Ok(response);
        }

        // POST api/<EmployeeController>/UpdateEmployee
        /// <summary>
        /// Altera dados do funcionário.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Sucesso</returns>
        /// <remarks>
        /// Função recebe todos os dados em JSON para alteração no banco de dados.
        /// Sample request
        ///     POST/UpdateEmployee
        ///     {
        ///          "name": Ronaldo Ferreira Martins
        ///          "email": "ronaldo.martins@ex.com",
        ///          "CPF": "12345678901",
        ///          "phone": "5512987654321",
        ///          "birthDate": "1985-04-20",
        ///          "employeeContractType": 2,
        ///          "status": 1
        ///     }
        /// </remarks>
        /// <response code="200">Retorna sucesso ao atualizar funcionário;</response>
        /// <response code="400">Se não for possível atualizar dados do funcionário;</response> 
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee request)
        {
            BaseResponse response = new();

            try
            {
                _employeeService.UpdateEmployee(request);

                response.Message = "Operação concluída com sucesso, funcionário atualizado.";
                response.Success = true;
            }
            catch (InvalidOperationException ex)
            {
                response.ErrorId = ErrorCodes.EmployeeDoesNotExist;
                response.Error = ex.Message;
                response.Message = ResponseMessages.EmployeeDoesNotExist;

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.ErrorId = ErrorCodes.GeneralErrorUpdatingEmployee;
                response.Error = ex.Message;
                response.Message = ResponseMessages.GeneralOperationFailed;

                return BadRequest(response);
                throw new Exception("Error", ex);
            }

            return Ok(response);
        }

        // PUT api/<EmployeeController>/InactivateEmployee
        /// <summary>
        /// Altera status do funcionário.
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="Status"></param>
        /// <returns>Sucesso</returns>
        /// <response code="200">Retorna sucesso ao mudar status do funcionário</response>
        /// <response code="400">Se não for possível mudar status do funcionário</response> 
        [HttpPut("HandleStatusEmployee/{EmployeeId}/{Status}")]
        public IActionResult HandleStatusEmployee(Guid EmployeeId, EStatus Status)
        {
            BaseResponse response = new();

            try
            {
                _employeeService.HandleStatusEmployee(EmployeeId, Status);

                response.Message = "Operação concluída com sucesso, funcionário " + Status;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorId = ErrorCodes.ErrorChangingEmployeeStatus;
                response.Error = ex.Message;
                response.Message = ResponseMessages.GeneralOperationFailed;

                return BadRequest(response);
                throw new Exception("Error", ex);
            }

            return Ok(response);
        }

        // DELETE api/<EmployeeController>/DeleteEmployee
        /// <summary>
        /// Remove funcionário do banco de dados.
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns>Sucesso</returns>
        /// <response code="200">Retorna sucesso ao remover funcionário do banco de dados</response>
        /// <response code="400">Se não for possível remover funcionário do banco de dados</response> 
        [HttpDelete("DeleteEmployee/{EmployeeId}")]
        public IActionResult DeleteEmployee(Guid EmployeeId)
        {
            BaseResponse response = new();

            try
            {
                _employeeService.DeleteEmployee(EmployeeId);

                response.Message = "Operação concluída com sucesso, funcionário removido do banco.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorId = ErrorCodes.ErrorDeletingEmployee;
                response.Error = ex.Message;
                response.Message = ResponseMessages.GeneralOperationFailed;

                return BadRequest(response);
                throw new Exception("Error", ex);
            }

            return Ok(response);
        }
    }

}
