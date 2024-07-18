using System.ComponentModel.DataAnnotations;

namespace AnotherMusicAPI.Model;
public class Music
{
    [Key]
    public int MusicId { get; set; }
    
    [Required]
    public string MusicName { get; set; } = string.Empty;

    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
}