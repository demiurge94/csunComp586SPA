using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.ViewModels
{
    public class ArtistDetailVm
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistBio { get; set; }
        public ICollection<AlbumVm> Albums { get; set; }
        public string Genre { get; set; }
    }
}
