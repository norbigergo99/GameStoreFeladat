using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace GameStoreBeGNorbi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string PasswordSalt { get; set; } = string.Empty;
        public virtual ICollection<VideoGame> VideoGames { get; } = new List<VideoGame>();
    }
}
