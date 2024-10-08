using doQrApi.Objects.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace doQrApi.Entites
{
    public class Employee
    {
        [Required]
        
        public Guid EmployeeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF must contain 11 digits.")]
        public string? CPF { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public EContractType EmployeeContractType { get; set; }

        [Required]
        public EStatus Status { get; set; }

        public DateTime? Created_at { get; }
    }
}
