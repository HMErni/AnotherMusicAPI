using System.ComponentModel.DataAnnotations;

namespace AnotherMusicAPI.Model
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}