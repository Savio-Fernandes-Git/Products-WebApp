using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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