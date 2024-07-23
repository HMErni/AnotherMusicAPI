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
        private readonly IArtistRepo _artistRepo;

        public MusicController(IMusicRepo repository, IGenreRepo genreRepo, IArtistRepo artistRepo, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _genreRepo = genreRepo;
            _artistRepo = artistRepo;
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

            var artists = new List<Artist>();
            foreach (var artistId in musicDTO.ArtistIds)
            {
                var artist = await _artistRepo.GetArtistById(artistId);
                if (artist == null)
                    return BadRequest("Artist not found");

                artists.Add(artist);
            }

            music.Artists = artists;

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

            var artists = new List<Artist>();

            foreach (var artistId in musicDTO.ArtistIds)
            {
                var artist = await _artistRepo.GetArtistById(artistId);
                if (artist == null)
                    return BadRequest("Artist not found");

                artists.Add(artist);
            }

            music.Artists = artists;

            await _repository.UpdateMusic(music);
            await _repository.SaveChanges();

            return Ok(music);
        }

        [HttpDelete("{musicId}")]
        public async Task<ActionResult> DeleteMusic(int musicId)
        {
            var music = await _repository.GetMusicById(musicId);
            if (music == null)
                return NotFound();

            _repository.DeleteMusic(music);
            await _repository.SaveChanges();

            return NoContent();
        }
    }
}