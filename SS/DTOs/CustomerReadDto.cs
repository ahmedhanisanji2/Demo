using SS.Models;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public decimal Total {  get; set; }
        public ICollection<ArtPieceDtoReadForCustomer> artPieces { get; set; }

        public LoyaltyCardDtoReadForCustomer LoyaltyCard { get; set; }
    }
    public class ArtPieceDtoReadForCustomer
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
    public class LoyaltyCardDtoReadForCustomer
    {
        public int Id { get; set; }
        [Required]
        public string CardNumber { get; set; }

        public Decimal Blalnce { get; set; }


    }
}
