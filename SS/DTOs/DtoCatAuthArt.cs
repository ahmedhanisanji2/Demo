using SS.Models;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    public class DtoCatAuthArt
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public decimal TotalRevenue {  get; set; }
        public ICollection<DtoAART> artPieces { get; set; } = new List<DtoAART>();
    }
    public class DtoAART
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, Range(1, int.MaxValue)]
        public Decimal Price { get; set; }

        public int CustomerID { get; set; }
        public DtoCUSTT? Customer { get; set; }
    }
    public class DtoCUSTT
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DtoLay LoyaltyCard { get; set; }
    }
    public class DtoLay
    {
        public int Id { get; set; }
        [Required]
        public string CardNumber { get; set; }

        public Decimal Blalnce { get; set; }

        public int CustomerId { get; set; }
    }
}