using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs
{
    public class AlbumReadDTO
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; } = string.Empty;
        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}