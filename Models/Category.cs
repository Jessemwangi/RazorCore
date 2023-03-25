using System.ComponentModel.DataAnnotations;

namespace RazorCore.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string? Name { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}
