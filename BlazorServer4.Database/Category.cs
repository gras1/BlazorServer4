using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer4.Database
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
