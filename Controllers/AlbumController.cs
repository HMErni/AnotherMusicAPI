using AnotherMusicAPI.Data;
using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherMusicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMusicRepo _musicRepo;

        public AlbumController(IAlbumRepo repository, IMusicRepo musicRepo, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _musicRepo = musicRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumReadDTO>>> GetAllAlbums()
        {
            var albums = await _repository.GetAllAlbums();
            return Ok(_mapper.Map<IEnumerable<AlbumReadDTO>>(albums));
        }

        [HttpGet("{albumId}")]
        public async Task<ActionResult<AlbumReadDTO>> GetAlbumById(int albumId)
        {
            var album = await _repository.GetAlbumById(albumId);
            if (album == null)
                return NotFound();

            return Ok(_mapper.Map<AlbumReadDTO>(album));
        }

        [HttpPost]
        public async Task<ActionResult<AlbumCreateDTO>> CreateAlbum([FromBody] AlbumCreateDTO albumDTO)
        {

            var album = _mapper.Map<Album>(albumDTO);

            var musics = new List<Music>();
            foreach (var musicId in albumDTO.MusicIds)
            {
                var music = await _musicRepo.GetMusicById(musicId);
                if (music == null)
                    return BadRequest("Music not found");

                musics.Add(music);
            }

            album.Musics = musics;

            await _repository.CreateAlbum(album);
            await _repository.SaveChanges();

            var albumReadDTO = _mapper.Map<AlbumReadDTO>(album);

            return CreatedAtAction(nameof(GetAlbumById), new { albumId = album.AlbumId }, albumReadDTO);
        }

        [HttpPut("{albumId}")]
        public async Task<ActionResult<AlbumUpdateDTO>> UpdateAlbum(int albumId, AlbumUpdateDTO albumDTO)
        {
            var album = await _repository.GetAlbumById(albumId);
            if (album == null)
                return NotFound();

            _mapper.Map(albumDTO, album);

            var musics = new List<Music>();
            foreach (var musicId in albumDTO.MusicIds)
            {
                var music = await _musicRepo.GetMusicById(musicId);
                if (music == null)
                    return BadRequest("Music not found");

                musics.Add(music);
            }

            album.Musics = musics;

            await _repository.UpdateAlbum(album);
            await _repository.SaveChanges();

            return Ok(album);
        }

        [HttpDelete("{albumId}")]
        public async Task<ActionResult> DeleteAlbum(int albumId)
        {
            var album = await _repository.GetAlbumById(albumId);
            if (album == null)
                return NotFound();

            _repository.DeleteAlbum(album);
            await _repository.SaveChanges();

            return NoContent();
        }
    }
}