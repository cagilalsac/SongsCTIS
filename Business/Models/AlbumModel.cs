#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
