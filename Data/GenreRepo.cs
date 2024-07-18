using AnotherMusicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Data
{
    public class GenreRepo : IGenreRepo
    {
        private readonly DataContext _context;

        public GenreRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateGenre(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));

            await _context.Genres.AddAsync(genre);
        }

        public async Task UpdateGenre(Genre genre)
        {
            // ?????
        }

        public void DeleteGenre(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));

            _context.Genres.Remove(genre);

        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _context.Genres.Include(x => x.Musics).ToListAsync();
        }

        public async Task<Genre?> GetGenreById(int genreId)
        {
            return await _context.Genres.Include(x => x.Musics).FirstOrDefaultAsync(x => x.GenreId == genreId);
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync() >= 0;

            return result;
        }

    }
}