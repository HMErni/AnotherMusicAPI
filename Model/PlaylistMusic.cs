using System.ComponentModel.DataAnnotations;

namespace AnotherMusicAPI.Model
{
    public class PlaylistMusic
    {
        public int MusicId { get; set; }
        public int PlaylistId { get; set; }
    }
}