using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly DataContext DataContext;
        public IEnumerable<Product> products;

        public IndexModel(DataContext dataContext)
        {
            DataContext = dataContext;
            products = new List<Product>();
        }

        public void OnGet()
        {
            products = DataContext.products.Include(c => c.Category) ;
        }
    }
}
