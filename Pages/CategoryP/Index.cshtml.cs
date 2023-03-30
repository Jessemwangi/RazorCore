using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCore.Infrastructures;
using RazorCore;
using Microsoft.EntityFrameworkCore;
using RazorCore.Models;

namespace RazorCore.Pages.CategoryP
{
    public class IndexModel : PageModel
    {
        private readonly DataContext DataContext;
        public IEnumerable<Category> categories;
        public IndexModel(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task OnGet()
        {
            categories = await DataContext.categories.Include(C => C.Products).ToListAsync();
        }
     
        public async Task OnPost(Category category)
        {
            DataContext.categories.Add(category);
            await DataContext.SaveChangesAsync();
        }
       
    }
}
