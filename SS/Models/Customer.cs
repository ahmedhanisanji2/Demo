using System.ComponentModel.DataAnnotations;

namespace SS.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public ICollection<ArtPiece> artPieces { get; set; }

        public LoyaltyCard LoyaltyCard { get; set; }
    }
}
