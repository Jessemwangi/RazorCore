using System.ComponentModel.DataAnnotations;

namespace RazorCore.Models
{
    public class Category
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = $"Please enter a value between 1 and ")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
