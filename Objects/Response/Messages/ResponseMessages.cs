namespace doQrApi.Objects.Response.Messages
{
    public class ResponseMessages
    {
        // Success Messages
        public const string EmployeeAddedSuccess = "Operação concluída com sucesso, funcionário adicionado.";
        public const string EmployeeUpdatedSuccess = "Operação concluída com sucesso, funcionário atualizado.";
        public const string EmployeeStatusUpdatedSuccess = "Operação concluída com sucesso, funcionário {0}.";
        public const string EmployeeDeletedSuccess = "Operação concluída com sucesso, funcionário removido do banco.";

        // Error Messages
        public const string GeneralOperationFailed = "Operação falhou.";
        public const string EmployeeAlreadyExists = "Funcionário já existe.";
        public const string EmployeeDoesNotExist = "Funcionário não existe.";
    }
}
