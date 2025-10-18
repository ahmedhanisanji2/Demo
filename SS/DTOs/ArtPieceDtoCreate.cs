using SS.Models;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    public class ArtPieceDtoCreate
    {
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, Range(1, int.MaxValue)]
        public Decimal Price { get; set; }

        public int CustomerID { get; set; }
        public List<int>? categories { get; set; }
    }
}
