using AnotherMusicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Data
{
    public class MusicRepo : IMusicRepo
    {
        private readonly DataContext _context;

        public MusicRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateMusic(Music music)
        {

            if (music == null)
                throw new ArgumentNullException(nameof(music));


            await _context.Musics.AddAsync(music);

        }

        public async Task UpdateMusic(Music music)
        {
            // ?????
        }

        public void DeleteMusic(Music music)
        {
            if (music == null)
                throw new ArgumentNullException(nameof(music));

            _context.Musics.Remove(music);
        }

        public async Task<IEnumerable<Music>> GetAllMusics()
        {
            return await _context.Musics.Include(x => x.Genre)
                .Include(x => x.Artists).ToListAsync();
        }

        public async Task<Music?> GetMusicById(int musicId)
        {
            return await _context.Musics.Include(x => x.Genre)
                .Include(x => x.Artists).FirstOrDefaultAsync(x => x.MusicId == musicId);
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            return result;
        }
    }
}