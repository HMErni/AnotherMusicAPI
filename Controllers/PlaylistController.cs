
using AnotherMusicAPI.Data;
using AnotherMusicAPI.Data.PlaylistRepo;
using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.DTOs.Playlist;
using AnotherMusicAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherMusicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepo _playlistRepo;
        private readonly IMusicRepo _musicRepo;
        private readonly IMapper _mapper;

        public PlaylistController(IPlaylistRepo playlistRepo, IMusicRepo musicRepo, IMapper mapper)
        {
            _playlistRepo = playlistRepo;
            _musicRepo = musicRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistReadDTO>>> GetAllPlaylists()
        {
            var playlists = await _playlistRepo.GetAllPlaylists();

            return Ok(_mapper.Map<IEnumerable<PlaylistReadDTO>>(playlists));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistReadDTO>> GetPlaylistById(int id)
        {
            var playlist = await _playlistRepo.GetPlaylistById(id);

            if (playlist == null)
                return NotFound();

            return Ok(_mapper.Map<PlaylistReadDTO>(playlist));
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistReadDTO>> CreatePlaylist([FromBody] PlaylistCreateDTO playlistDTO)
        {
            var playlist = _mapper.Map<Playlist>(playlistDTO);

            if (playlist == null)
                return BadRequest();

            var musics = new List<Music>();
            foreach (var musicId in playlistDTO.MusicIds)
            {
                var music = await _musicRepo.GetMusicById(musicId);
                if (music == null)
                    return BadRequest("Music not found");

                musics.Add(music);
            }

            playlist.Musics = musics;

            await _playlistRepo.CreatePlaylist(playlist);
            await _playlistRepo.SaveChanges();

            var playlistReadDTO = _mapper.Map<PlaylistReadDTO>(playlist);

            return CreatedAtAction(nameof(GetPlaylistById), new { id = playlist.Id }, playlistReadDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlaylistUpdateDTO>> UpdatePlaylist(int id, PlaylistUpdateDTO playlistDTO)
        {
            var playlist = await _playlistRepo.GetPlaylistById(id);
            if (playlist == null)
                return NotFound();

            _mapper.Map(playlistDTO, playlist);

            var musics = new List<Music>();
            foreach (var musicId in playlistDTO.MusicIds)
            {
                var music = await _musicRepo.GetMusicById(musicId);
                if (music == null)
                    return BadRequest("Music not found");

                musics.Add(music);

            }

            playlist.Musics = musics;

            await _playlistRepo.UpdatePlaylist(playlist);
            await _playlistRepo.SaveChanges();

            return Ok(playlist);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaylist(int id)
        {
            var playlist = await _playlistRepo.GetPlaylistById(id);
            if (playlist == null)
                return NotFound();

            _playlistRepo.DeletePlaylist(playlist);
            await _playlistRepo.SaveChanges();

            return NoContent();
        }
    }
}