using DemiAPI.Interfaces;
using DemiAPI.Models;
using DemiAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.Services
{
    public class ArtistService : IArtistService
    {
        private readonly MetalMusicContext _context;
        private readonly IGenreService _genreService;
        private readonly IAlbumService _albumService;
        public ArtistService(MetalMusicContext context, IGenreService genreService, IAlbumService albumService )
        {
            _context = context;
            _genreService = genreService;
            _albumService = albumService;
        }
        public ArtistDetailVm getArtistDetails(string name)
        {
            Console.WriteLine(_context.Artists.FindAsync(1).Result.ArtistId);
            ArtistDetailVm artistDetailVm = new()
            {
                ArtistName = name,
                ArtistId = _context.Artists.FindAsync(1).Result.ArtistId,
                //Genre = _genreService.GetArtistGenreInfo(_context.Artists.FindAsync(1).Result.ArtistId),
                
            };
            return artistDetailVm;
        }
    }
}
