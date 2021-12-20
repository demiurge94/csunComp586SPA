using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DemiAPI.Models
{
    [Index(nameof(ArtistGenreId), Name = "IX_Artists_Artist_genre_id")]
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        [Key]
        [Column("Artist_id")]
        public int ArtistId { get; set; }
        [Column("Artist_name")]
        [StringLength(50)]
        public string ArtistName { get; set; }
        [Column("Artist_bio")]
        public string ArtistBio { get; set; }
        [Column("Artist_genre_id")]
        public int ArtistGenreId { get; set; }
        [Column("Artist_Bass")]
        public string ArtistBass { get; set; }
        [Column("Artist_Drums")]
        public string ArtistDrums { get; set; }
        [Column("Artist_Guitar_one")]
        public string ArtistGuitarOne { get; set; }
        [Column("Artist_Guitar_two")]
        public string ArtistGuitarTwo { get; set; }
        [Column("Artist_Singer")]
        public string ArtistSinger { get; set; }

        [ForeignKey(nameof(ArtistGenreId))]
        [InverseProperty(nameof(Genre.Artists))]
        public virtual Genre ArtistGenre { get; set; }
        [InverseProperty(nameof(Album.AlbumArtist))]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
