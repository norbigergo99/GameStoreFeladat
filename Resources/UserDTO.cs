using System.ComponentModel.DataAnnotations;

namespace GameStoreBeGNorbi.Resources
{
    public record CreateUserDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        public CreateUserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
    public record UpdateUserDTO
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(150)]
        public string Email { get; set; }
        public UpdateUserDTO(string email) { Email = email; }
    }
}
