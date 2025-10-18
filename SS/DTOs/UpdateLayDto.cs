using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    [Index(nameof(CardNumber),IsUnique = true)]
    public class UpdateLayDto
    {
        [Required]
        public string CardNumber { get; set; }

        public Decimal Blalnce { get; set; }
    }
}
