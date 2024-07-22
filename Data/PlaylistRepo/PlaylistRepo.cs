using AnotherMusicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Data.PlaylistRepo
{
    public class PlaylistRepo : IPlaylistRepo
    {
        private readonly DataContext _context;

        public PlaylistRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreatePlaylist(Playlist playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException(nameof(playlist));

            await _context.Playlists.AddAsync(playlist);
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylists()
        {
            return await _context.Playlists
                .Include(p => p.Musics)
                    .ThenInclude(a => a.Artists)
                .Include(p => p.Musics)
                    .ThenInclude(g => g.Genre)
                .ToListAsync();
        }

        public async Task<Playlist?> GetPlaylistById(int id)
        {
            return await _context.Playlists
                .Include(p => p.Musics)
                    .ThenInclude(a => a.Artists)
                .Include(p => p.Musics)
                    .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePlaylist(Playlist playlist)
        {
            // ????
        }

        public void DeletePlaylist(Playlist playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException(nameof(playlist));

            _context.Playlists.Remove(playlist);
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            return result;
        }
    }
}