using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnotherMusicAPI.Model;
public class Music
{
    [Key]
    public int MusicId { get; set; }

    [Required]
    public string MusicName { get; set; } = string.Empty;

    public int GenreId { get; set; }

    [JsonIgnore]
    public Genre? Genre { get; set; }
}