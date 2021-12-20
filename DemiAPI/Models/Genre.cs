using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DemiAPI.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Artists = new HashSet<Artist>();
        }

        [Key]
        [Column("Genre_id")]
        public int GenreId { get; set; }
        [Column("Genre_name")]
        [StringLength(50)]
        public string GenreName { get; set; }
        [Column("Genre_emergence_year")]
        public int? GenreEmergenceYear { get; set; }
        [Column("Genre_description")]
        public string GenreDescription { get; set; }
        [Column("Derived_from")]
        public string DerivedFrom { get; set; }

        [InverseProperty(nameof(Artist.ArtistGenre))]
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
