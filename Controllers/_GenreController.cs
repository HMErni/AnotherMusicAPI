// using AnotherMusicAPI.Data;
// using AnotherMusicAPI.DTOs;
// using AnotherMusicAPI.Model;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace AnotherMusicAPI.Controllers{

//     [ApiController]
//     [Route("api/[controller]")]
//     public class GenreController : ControllerBase
//     {
//         private readonly DataContext _context;

//         public GenreController(DataContext context){
//             _context = context;
//         }


//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<ReadGenreDTO>>> GetAllGenres()
//         {
//             var genres = await _context.Genres.ToListAsync();
//             return Ok(await _context.Genres.ToListAsync());
//         }

//         [HttpGet("{genreId}")]
//         public async Task<ActionResult<ReadGenreDTO>> GetGenreById(int genreId)
//         {
//             return Ok(await _context.Genres.FindAsync(genreId));
//         }

//         [HttpPost]
//         public async Task<ActionResult> CreateGenre(CreateGenreDTO genreDTO)
//         {
//             var genre = new Genre{GenreName = genreDTO.GenreName};

//             await _context.Genres.AddAsync(genre);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetGenreById), new {genreId = genre.GenreId}, genre);
//         }

//         [HttpDelete("{genreId}")]
//         public async Task<ActionResult> DeleteGenre(int genreId)
//         {
//             var genre = await _context.Genres.FindAsync(genreId);

//             if (genre == null)
//                 return NotFound();

//             _context.Genres.Remove(genre);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }