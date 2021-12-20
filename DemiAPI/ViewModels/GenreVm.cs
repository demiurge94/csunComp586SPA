using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.ViewModels
{
    public class GenreVm
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Predecessor { get; set; }
        public string Description { get; set; }

    }
}
