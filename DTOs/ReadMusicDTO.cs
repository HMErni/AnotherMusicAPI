using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs;

public class ReadMusicDTO{
    public int MusicId { get; set; }
    
    public string MusicName { get; set; } = string.Empty;

    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
}