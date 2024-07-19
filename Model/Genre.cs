using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnotherMusicAPI.Model;
public class Genre
{
    [Key]
    public int GenreId { get; set; }

    [Required]
    public string GenreName { get; set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<Music> Musics { get; } = new List<Music>();

}