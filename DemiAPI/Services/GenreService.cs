using DemiAPI.Interfaces;
using DemiAPI.Models;
using DemiAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.Services
{
    public class GenreService : IGenreService
     {
        private readonly MetalMusicContext _context; 
        public GenreService(MetalMusicContext context)
        {
            _context = context;
        }

        public SimpleGenreVm GetArtistGenreInfo(int genreId)
        {
            SimpleGenreVm simpleGenreVm = new()
            {
                Name =  _context.Genres.FindAsync(genreId).Result.GenreName,
                GenreId = genreId
            };
            return simpleGenreVm;
        }
    }
}
