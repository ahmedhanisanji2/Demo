using System.ComponentModel.DataAnnotations;

namespace SS.Models
{
    public class ArtPiece
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required,Range(1,int.MaxValue)]
        public Decimal Price { get; set; }  

        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<Category> categories { get; set; } = new List<Category>();
    }
}
