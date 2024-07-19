using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.Data
{
    public interface IGenreRepo
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre?> GetGenreById(int genreId);
        Task CreateGenre(Genre genre);

        Task UpdateGenre(Genre genre);

        void DeleteGenre(Genre genre);

        Task<bool> SaveChanges();
    }
}