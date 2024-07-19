using AnotherMusicAPI.Data;
using AnotherMusicAPI.DTOs;
using AnotherMusicAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnotherMusicAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo _repository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreReadDTO>>> GetAllGenres()
        {
            var genres = await _repository.GetAllGenres();

            return Ok(_mapper.Map<IEnumerable<GenreReadDTO>>(genres));
        }

        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreReadDTO>> GetGenreById(int genreId)
        {
            var genre = await _repository.GetGenreById(genreId);

            if (genre == null)
                return NotFound();

            return Ok(_mapper.Map<GenreReadDTO>(genre));
        }

        [HttpPost]
        public async Task<ActionResult<GenreReadDTO>> CreateGenre(GenreCreateDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            await _repository.CreateGenre(genre);
            await _repository.SaveChanges();

            var genreReadDTO = _mapper.Map<GenreReadDTO>(genre);

            return CreatedAtAction(nameof(GetGenreById), new { genreId = genre.GenreId }, genreReadDTO);
        }

        [HttpPut("{genreId}")]
        public async Task<ActionResult<GenreUpdateDTO>> UpdateGenre(int genreId, GenreUpdateDTO genreDTO)
        {
            var genre = await _repository.GetGenreById(genreId);
            if (genre == null)
                return NotFound();

            _mapper.Map(genreDTO, genre);

            await _repository.UpdateGenre(genre);
            await _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{genreId}")]
        public async Task<ActionResult> DeleteGenre(int genreId)
        {
            var genre = await _repository.GetGenreById(genreId);
            if (genre == null)
                return NotFound();

            _repository.DeleteGenre(genre);
            await _repository.SaveChanges();

            return NoContent();
        }



    }
}