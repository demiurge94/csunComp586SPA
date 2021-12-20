using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DemiAPI.Models
{
    [Index(nameof(AlbumArtistId), Name = "IX_Albums_Album_Artist_Id")]
    public partial class Album
    {
        [Key]
        [Column("Album_id")]
        public int AlbumId { get; set; }
        [Column("Album_name")]
        [StringLength(100)]
        public string AlbumName { get; set; }
        [Column("Album_year")]
        public int? AlbumYear { get; set; }
        [Column("Album_Artist_Id")]
        public int AlbumArtistId { get; set; }
        [Column("Album_label")]
        public string AlbumLabel { get; set; }
        [Column("Album_Release_Number")]
        public int AlbumReleaseNumber { get; set; }
        [Column("Album_sales")]
        public int AlbumSales { get; set; }

        [ForeignKey(nameof(AlbumArtistId))]
        [InverseProperty(nameof(Artist.Albums))]
        public virtual Artist AlbumArtist { get; set; }
    }
}
