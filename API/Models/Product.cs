using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public virtual Category Category { get; set; }
    }
}