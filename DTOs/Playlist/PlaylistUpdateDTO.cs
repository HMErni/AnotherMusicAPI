namespace AnotherMusicAPI.DTOs.Playlist
{
    public class PlaylistUpdateDTO
    {
        public string Name { get; set; } = string.Empty;

        public List<int> MusicIds { get; set; } = new List<int>();
    }
}