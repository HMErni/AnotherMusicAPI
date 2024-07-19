using AnotherMusicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Data
{
    public class AlbumRepo : IAlbumRepo
    {
        private readonly DataContext _context;

        public AlbumRepo(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            await _context.Albums.AddAsync(album);
        }

        public void DeleteAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _context.Albums.Remove(album);
        }

        public async Task<Album?> GetAlbumById(int albumId)
        {
            return await _context.Albums.Include(x => x.Musics).FirstOrDefaultAsync(x => x.AlbumId == albumId);
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await _context.Albums.Include(x => x.Musics).ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            return result;
        }

        public async Task UpdateAlbum(Album album)
        {
            /// ?????
        }
    }
}