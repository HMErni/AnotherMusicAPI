using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.DTOs{

    public class CreateMusicDTO{
        public string MusicName { get; set; } = string.Empty;

        public int GenreId { get; set; }

    }
}