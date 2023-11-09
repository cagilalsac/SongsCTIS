#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class SongModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int? Year { get; set; }

        public decimal Rating { get; set; }

        [DisplayName("Album")]
        [Required]
        public int? AlbumId { get; set; }



        [DisplayName("Album")]
        public string AlbumOutput { get; set; }
    }
}
