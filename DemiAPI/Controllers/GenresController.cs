using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemiAPI.Models;
using DemiAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GenresController : ControllerBase
    {
        private readonly MetalMusicContext _context;

        public GenresController(MetalMusicContext context)
        {
            _context = context;
        }

        // GET: api/Genres

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GenreArtistsVm>>> GetGenreDetails(int id)
        {
            IQueryable<GenreArtistsVm> genreDetails = _context.Genres.Where(a => a.GenreId == id).Select(a => new GenreArtistsVm
            {
                GenreId = a.GenreId,
                GenreName = a.GenreName,
                Artists = _context.Artists.Where(c => c.ArtistGenreId == a.GenreId).Select(c => new ArtistVm()
                {
                    ArtistId = c.ArtistId,
                    ArtistName = c.ArtistName,
                 
                }).ToList()
            }); ;
            Console.WriteLine(genreDetails.ToQueryString());
            return await genreDetails.ToListAsync();
            
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GenreVm>>> GetGenres()
        {
            IQueryable<GenreVm> genres = _context.Genres.Where(c => c.GenreId > 0).Select(a => new GenreVm
            {
                GenreId = a.GenreId,
                Year = a.GenreEmergenceYear,
                Name = a.GenreName,
                Predecessor = a.DerivedFrom,
                Description = a.GenreDescription
            });

            return await genres.ToListAsync();
            //return await _context.Genres.ToListAsync();
        }
        /*example like professor's 
         * [HttpGet]
         * public async Task<List<Genre>>Get()
         * {
         *      IQueryable<Genre> genre = _context.Genres.Where(c => c.GenreId <3);
         *      return await genres.ToListAsync(); 
         * }
         */
        // GET: api/Genres/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
           //IQueryable<Genre> genre = _context.Genres.Where(c=> c.GenreId <3);
        } */

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.GenreId)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GenreExists(genre.GenreId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGenre", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.GenreId == id);
        }
    }
}
