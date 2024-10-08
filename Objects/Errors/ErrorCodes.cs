namespace doQrApi.Objects.Errors
{
    /// <summary>
    /// Contains standardized error codes for employee-related operations.
    /// </summary>
    public class ErrorCodes
    {
        /// <summary>
        /// General error fetching all employees.
        /// </summary>
        public const string GeneralErrorFetchingAllEmployees = "C0001";

        /// <summary>
        /// General error fetching employee by name.
        /// </summary>
        public const string GeneralErrorFetchingEmployeeByName = "C0002";

        /// <summary>
        /// General error adding employee.
        /// </summary>
        public const string GeneralErrorAddingEmployee = "C0003";

        /// <summary>
        /// General error updating employee.
        /// </summary>
        public const string GeneralErrorUpdatingEmployee = "C0004";

        /// <summary>
        /// Employee already exists.
        /// </summary>
        public const string EmployeeAlreadyExists = "C0101";

        /// <summary>
        /// Employee does not exist (for updating).
        /// </summary>
        public const string EmployeeDoesNotExist = "C0112";

        /// <summary>
        /// Error changing employee status.
        /// </summary>
        public const string ErrorChangingEmployeeStatus = "C0113";

        /// <summary>
        /// Error deleting employee.
        /// </summary>
        public const string ErrorDeletingEmployee = "C0114";
    }

}
