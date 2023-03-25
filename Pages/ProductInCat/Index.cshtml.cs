using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Models;
using System.Collections;

namespace RazorCore.Pages.ProductInCat
{
    public class IndexModel : PageModel
    {
        private readonly DataContext DataContext;
        public IEnumerable<Product> Products;
        public Category Category;   

        public IndexModel(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task OnGet(long id)
        {
            //    Products =  await DataContext.products.Include(p => p.Category)
            //.Where(c => c.CategoryId ==id).ToListAsync();
            Category = await DataContext.categories.FindAsync(id);
        Products = await DataContext.products.Where(x => x.CategoryId == id).ToListAsync();
            
        }
    }
}
