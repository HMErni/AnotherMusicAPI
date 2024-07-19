namespace AnotherMusicAPI.DTOs
{
    public class AlbumCreateDTO
    {
        public string AlbumName { get; set; } = string.Empty;
        public List<int> MusicIds { get; set; } = new List<int>();
    }
}