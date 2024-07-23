using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.Data.PlaylistRepo
{
    public interface IPlaylistRepo
    {
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<Playlist?> GetPlaylistById(int id);
        Task CreatePlaylist(Playlist playlist);
        Task UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(Playlist playlist);
        Task<bool> SaveChanges();

    }
}