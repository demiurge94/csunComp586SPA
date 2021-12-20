using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.ViewModels
{
    public class GenreArtistsVm
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<ArtistVm> Artists { get; set; }

    }
}
