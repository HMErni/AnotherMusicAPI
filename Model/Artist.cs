using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.Model{

    public class Artist{
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}