using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SS.Models
{
    [Index(nameof(CardNumber),IsUnique = true)]
    public class LoyaltyCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CardNumber { get; set; }

        public Decimal Blalnce { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
