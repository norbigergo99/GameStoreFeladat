using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameStoreBeGNorbi.Models
{
    public class UserVideoGame
    {
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [Required, ForeignKey("VideoGame")]
        public int VideoGameId { get; set; }
        [JsonIgnore]
        public VideoGame? VideoGame { get; set; }
    }
}