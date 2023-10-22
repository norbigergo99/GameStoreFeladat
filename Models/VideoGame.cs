using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameStoreBeGNorbi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Type
    {
        Akció = 1,
        Kaland,
        Coop,
        Oktató,
        Túlélő
    }
    
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [Required, EnumDataType(typeof(Type))]
        public Type Type { get; set; }
        [Required]
        public int Price { get; set; }
        [Required, Range(1, 5)]
        public int Rating { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public VideoGame (string title, string description, Type type, int price, int rating)
        {
            Title = title;
            Description = description;
            Type = type;
            Price = price;
            Rating = rating;
        }
    }
}
