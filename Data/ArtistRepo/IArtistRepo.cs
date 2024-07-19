using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.Data
{
    public interface IArtistRepo
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist?> GetArtistById(int artistId);
        Task CreateArtist(Artist artist);

        Task UpdateArtist(Artist artist);

        void DeleteArtist(Artist artist);

        Task<bool> SaveChanges();
    }
}