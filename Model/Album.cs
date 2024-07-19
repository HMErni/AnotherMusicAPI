using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnotherMusicAPI.Model
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Music> Musics { get; set;} = new List<Music>();

    }
    
}