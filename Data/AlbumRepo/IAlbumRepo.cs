using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.Data
{
    public interface IAlbumRepo
    {
        Task <IEnumerable<Album>> GetAllAlbums();
        Task<Album?> GetAlbumById(int albumId);
        Task CreateAlbum(Album album);
        Task UpdateAlbum(Album album);
        void DeleteAlbum(Album album);
        Task<bool> SaveChanges();
    }
}