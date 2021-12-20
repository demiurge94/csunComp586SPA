using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemiAPI.Models;
using DemiAPI.ViewModels;

namespace DemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly MetalMusicContext _context;
        public ArtistsController(MetalMusicContext context )
        {
            _context = context;
           
        }

        // GET: api/Artists
        [HttpGet("{name}/albums")]
        public async Task<ActionResult<IEnumerable<ArtistDetailVm>>> GetArtistsDetails(string name)
        {
            IQueryable<ArtistDetailVm> artistDetal = _context.Artists.Include(a => a.ArtistGenre).Where(a => a.ArtistName == name).Select(a => new ArtistDetailVm
            {
                ArtistName = a.ArtistName,
                ArtistId = a.ArtistId,
                ArtistBio = a.ArtistBio,
                Genre = a.ArtistGenre.GenreName,
                Albums =  _context.Albums.Where(c => c.AlbumArtistId == a.ArtistId).Select(c => new AlbumVm
                {
                    AlbumVmId = c.AlbumId,
                    AlbumName = c.AlbumName,

                }).ToList()

            });

            

            

            return await artistDetal.ToListAsync();
        }

        
     

        // GET: api/Artists/5
        [HttpGet]
       //public async Task<ActionResult<IEnumerable<aristlist>>> GetArtist(int id)
       public async Task<ActionResult<IEnumerable<ArtistListModeVm>>> GetArtists() 
        {
            /*IQueryable<ArtistVm> artists = _context.Artists.Where(a => a.ArtistGenreId == id).Select(a => new ArtistVm
            {
                Genre = a.ArtistGenreId,
                ArtistId = a.ArtistId,
                ArtistName = a.ArtistName
            }) ;
            Console.WriteLine(artists.ToQueryString());
            var artists = await _context.Artists.Include()*/
            var artists = _context.Artists.Include(a => a.ArtistGenre).Select(a => new ArtistListModeVm
            {
                Genre = a.ArtistGenre.GenreName,
                ArtistBio = a.ArtistBio,
                ArtistId = a.ArtistId,
                ArtistName = a.ArtistName
            });
            return await artists.ToListAsync();
        } 

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArtistExists(artist.ArtistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
