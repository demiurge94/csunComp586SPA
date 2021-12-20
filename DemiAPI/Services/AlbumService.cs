using DemiAPI.Interfaces;
using DemiAPI.Models;
using DemiAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly MetalMusicContext _context;

        public AlbumService (MetalMusicContext context)
        {
            _context = context;
        }

        public async Task<ICollection<AlbumVm>> GetAlbums(int artistId) {

            IQueryable<AlbumVm> albumsByArtist = _context.Albums.Where(a => a.AlbumArtistId == artistId).Select(a => new AlbumVm
            {
                AlbumVmId = a.AlbumId,
                AlbumName = a.AlbumName
            });


            return await albumsByArtist.ToListAsync();
        }

    }
}
