using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs{
    public class ArtistReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}