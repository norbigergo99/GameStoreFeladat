using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace GameStoreBeGNorbi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(150)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }
        [Required, MaxLength(255)]
        public string PasswordSalt { get; set; }
        public virtual ICollection<VideoGame> VideoGames { get; } = new List<VideoGame>();

        public User (string email, string passwordHash, string passwordSalt)
        {
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
