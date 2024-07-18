using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs
{
    public class MusicCreateDTO
    {
        public string MusicName { get; set; } = string.Empty;
        public int GenreId { get; set; }

    }
}