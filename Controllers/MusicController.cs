using AnotherMusicAPI.Data;
using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMusicRepo _repository;
        private readonly IGenreRepo _genreRepo;

        public MusicController(IMusicRepo repository, IGenreRepo genreRepo, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _genreRepo = genreRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicReadDTO>>> GetAllMusics()
        {
            var musics = await _repository.GetAllMusics();

            return Ok(_mapper.Map<IEnumerable<MusicReadDTO>>(musics));
        }

        [HttpGet("{musicId}")]
        public async Task<ActionResult<MusicReadDTO>> GetMusicById(int musicId)
        {
            var music = await _repository.GetMusicById(musicId);

            if (music == null)
                return NotFound();

            return Ok(_mapper.Map<MusicReadDTO>(music));
        }

        [HttpPost]
        public async Task<ActionResult<MusicReadDTO>> CreateMusic([FromBody] MusicCreateDTO musicDTO)
        {

            var music = _mapper.Map<Music>(musicDTO);

            var genre = await _genreRepo.GetGenreById(music.GenreId);
            if (genre == null)
                return BadRequest("Genre not found");

            music.Genre = genre;

            await _repository.CreateMusic(music);
            await _repository.SaveChanges();

            var musicReadDTO = _mapper.Map<MusicReadDTO>(music);

            return CreatedAtAction(nameof(GetMusicById), new { musicId = music.MusicId }, musicReadDTO);

        }

        [HttpPut("{musicId}")]
        public async Task<ActionResult<MusicUpdateDTO>> UpdateMusic(int musicId, MusicUpdateDTO musicDTO)
        {
            var music = await _repository.GetMusicById(musicId);
            if (music == null)
                return NotFound();

            _mapper.Map(musicDTO, music);

            await _repository.UpdateMusic(music);
            await _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{musicId}")]
        public async Task<ActionResult<MusicReadDTO>> DeleteMusic(int musicId)
        {
            var music = await _repository.GetMusicById(musicId);
            if (music == null)
                return NotFound();

            _repository.DeleteMusic(music);
            await _repository.SaveChanges();

            return Ok(_mapper.Map<MusicReadDTO>(music));
        }
    }
}