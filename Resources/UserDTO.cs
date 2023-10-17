using System.ComponentModel.DataAnnotations;

namespace GameStoreBeGNorbi.Resources
{
    public class UserDTO
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
