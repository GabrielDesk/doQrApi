// Entities/ContractType.cs
namespace doQrApi.Entities
{
    public class ContractType // Ensure this is a class, not a struct
    {
        public int ContractTypeId { get; set; } // Primary key 
        public string? ContractTypeName { get; set; } // Name of the contract type
    }
}
