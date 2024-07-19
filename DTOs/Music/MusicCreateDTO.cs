using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs
{
    public class MusicCreateDTO
    {
        public string MusicName { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public List<int> ArtistIds { get; set; } = new List<int>();

    }
}