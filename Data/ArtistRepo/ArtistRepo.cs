using AnotherMusicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Data
{
    public class ArtistRepo : IArtistRepo
    {
        private readonly DataContext _context;

        public ArtistRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateArtist(Artist artist)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            await _context.Artists.AddAsync(artist);
            
        }

        public void DeleteArtist(Artist artist)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            _context.Artists.Remove(artist);
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _context.Artists.Include(x => x.Musics).ToListAsync();
        }

        public async Task<Artist?> GetArtistById(int artistId)
        {
            return await _context.Artists.Include(x => x.Musics).FirstOrDefaultAsync(x => x.Id == artistId);
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            return result;
        }

        public async Task UpdateArtist(Artist artist)
        {
            // ?????
        }
    }
}