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
        public async Task<Category> GetCategory(long Id)
        {
            return await DataContext.categories.FindAsync(Id);
        }
        public async Task OnPost(Category category)
        {
            DataContext.categories.Add(category);
            await DataContext.SaveChangesAsync();
        }
        public async Task OnPatch()
        {
            var Sum = "emmkmf";
        }
        public async void OnDelete(long Id)
        {
            Category cat =await GetCategory(Id);
            if(cat != null)
            {
                DataContext.Remove(cat);
                DataContext.SaveChangesAsync();
            }
        }
    }
}
