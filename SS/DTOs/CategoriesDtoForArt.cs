using SS.Models;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    public class CategoriesDtoForArt
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int NumOfPiece { get; set; }

        public decimal AveragePrice { get; set; }

        public ICollection<ArtDto> artPieces { get; set; } = new List<ArtDto>();
    }
    public class ArtDto
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, Range(1, int.MaxValue)]
        public Decimal Price { get; set; }

        public int CustomerID { get; set; }
    }
}