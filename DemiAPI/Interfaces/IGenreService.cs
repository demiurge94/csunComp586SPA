using DemiAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.Interfaces
{
    public interface IGenreService
    {
        public SimpleGenreVm GetArtistGenreInfo(int genreId);
    }
}
