using SS.Models;
using System.ComponentModel.DataAnnotations;

namespace SS.DTOs
{
    public class DtoReadArt
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, Range(1, int.MaxValue)]
        public Decimal Price { get; set; }

        public int CustomerID { get; set; }
        public CustomerReadDtoForArt? Customer { get; set; }

        public ICollection<CategoryReadDtoForArt> categories { get; set; } = new List<CategoryReadDtoForArt>();
    }
    public class CustomerReadDtoForArt
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
    public class CategoryReadDtoForArt
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
