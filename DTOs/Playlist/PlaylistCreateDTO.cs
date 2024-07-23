namespace AnotherMusicAPI.DTOs.Playlist
{
    public class PlaylistCreateDTO
    {
        public string Name { get; set; } = string.Empty;

        public List<int> MusicIds { get; set; } = new List<int>();
    }
}