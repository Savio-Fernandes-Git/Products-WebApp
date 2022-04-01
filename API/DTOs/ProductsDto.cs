using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ProductsReadWriteDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }

    public class ProductDetailsReadDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }

    public class ProductDetailsReadPriceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
    }
}