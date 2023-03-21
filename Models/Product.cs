using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorCore.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be  greater than 0.01")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = $"Please enter a value between 1 and ")]
        public long CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
