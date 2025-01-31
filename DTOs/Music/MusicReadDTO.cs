using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs
{
    public class MusicReadDTO
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; } = string.Empty;
        public Genre? Genre { get; set; }
        public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
    }
}