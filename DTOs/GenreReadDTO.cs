using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs
{
    public class GenreReadDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}