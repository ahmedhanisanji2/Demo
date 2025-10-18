using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SS.Models
{
    [Index(nameof(Name),IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<ArtPiece> artPieces { get; set; }

    }
}
