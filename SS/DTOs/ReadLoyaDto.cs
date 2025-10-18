using SS.Models;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    public class ReadLoyaDto
    {
        public int Id { get; set; }
        [Required]
        public string CardNumber { get; set; }

        public Decimal Blalnce { get; set; }

        public int CustomerId { get; set; }
        public ReadLoyaDtoCus Customer { get; set; }
    }
    public class ReadLoyaDtoCus
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
