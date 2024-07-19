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


    [JsonIgnore]
    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
    [JsonIgnore]
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}