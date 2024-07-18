using AnotherMusicAPI.Data;
using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Controllers{ 
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly DataContext _context;

        public MusicController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadMusicDTO>>> GetAllMusics(){
            return Ok(await _context.Musics.Include(x => x.Genre).ToListAsync());
        }

        [HttpGet("{musicId}")]
        public async Task<ActionResult<ReadMusicDTO>> GetMusicById(int musicId)
        {
            return Ok(await _context.Musics.Include(x => x.Genre).FirstOrDefaultAsync(x => x.MusicId == musicId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMusic(CreateMusicDTO musicDTO){
            var music = new Music{
                MusicName = musicDTO.MusicName,
                GenreId = musicDTO.GenreId,
                Genre = await _context.Genres.FindAsync(musicDTO.GenreId)
            };

            await _context.Musics.AddAsync(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusicById), new {musicId = music.MusicId}, music);
        }

    }
}