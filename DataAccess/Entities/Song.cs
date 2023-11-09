#nullable disable

using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int? Year { get; set; }

        public decimal Rating { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
