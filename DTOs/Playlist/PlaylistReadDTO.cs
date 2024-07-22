using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs.Playlist
{
    public class PlaylistReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<MusicReadDTO> Musics { get; set; } = new List<MusicReadDTO>();
    }
}