using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products  { get; set; }
    }
}