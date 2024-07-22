using AnotherMusicAPI.Data;
using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherMusicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtisController : ControllerBase
    {
        private readonly IArtistRepo _artistRepo;
        private readonly IMapper _mapper;

        public ArtisController(IArtistRepo artistRepo, IMapper mapper)
        {
            _artistRepo = artistRepo;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistReadDTO>>> GetAllArtists()
        {
            var artists = await _artistRepo.GetAllArtists();
            return Ok(_mapper.Map<IEnumerable<ArtistReadDTO>>(artists));
        }

        [HttpGet("{artistId}")]
        public async Task<ActionResult<ArtistReadDTO>> GetArtistById(int artistId)
        {
            var artist = await _artistRepo.GetArtistById(artistId);
            if (artist == null)
                return NotFound();

            return Ok(_mapper.Map<ArtistReadDTO>(artist));
        }

        [HttpPost]
        public async Task<ActionResult<ArtistCreateDTO>> CreateArtist([FromBody] ArtistCreateDTO artistDTO)
        {
            var artist = _mapper.Map<Artist>(artistDTO);
            await _artistRepo.CreateArtist(artist);
            await _artistRepo.SaveChanges();

            var artistReadDTO = _mapper.Map<ArtistReadDTO>(artist);

            return CreatedAtAction(nameof(GetArtistById), new { artistId = artist.Id }, artistReadDTO);
        }

        [HttpPut("{artistId}")]
        public async Task<ActionResult<ArtistUpdateDTO>> UpdateArtist(int artistId, ArtistUpdateDTO artistDTO)
        {
            var artist = await _artistRepo.GetArtistById(artistId);
            if (artist == null)
                return NotFound();

            _mapper.Map(artistDTO, artist);

            await _artistRepo.UpdateArtist(artist);
            await _artistRepo.SaveChanges();

            return Ok(artist);
        }

        [HttpDelete("{artistId}")]
        public async Task<ActionResult> DeleteArtist(int artistId)
        {
            var artist = await _artistRepo.GetArtistById(artistId);
            if (artist == null)
                return NotFound();

            _artistRepo.DeleteArtist(artist);
            await _artistRepo.SaveChanges();

            return NoContent();
        }

    }
}