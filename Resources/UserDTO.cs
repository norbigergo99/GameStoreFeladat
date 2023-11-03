using System.ComponentModel.DataAnnotations;

namespace GameStoreBeGNorbi.Resources
{
    public record CreateUserDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(150, ErrorMessage = "Email address can not be longer than 150 characters")]
        public string Email { get; init; } = string.Empty;
        [MaxLength(255)]
        public string Password { get; init; } = string.Empty;
    }
    public record UpdateUserDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(150, ErrorMessage = "Email address can not be longer than 150 characters")]
        public string Email { get; init; } = string.Empty;
    }
}
