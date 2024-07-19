using AnotherMusicAPI.Model;

namespace AnotherMusicAPI.Data
{
    public interface IMusicRepo
    {
        Task<IEnumerable<Music>> GetAllMusics();
        Task<Music?> GetMusicById(int musicId);
        Task CreateMusic(Music music);
        Task UpdateMusic(Music music);
        void DeleteMusic(Music music);
        Task<bool> SaveChanges();
    }
}