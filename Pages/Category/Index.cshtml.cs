using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCore.Infrastructures;
using RazorCore;
using Microsoft.EntityFrameworkCore;

namespace RazorCore.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly DataContext DataContext;
        public IEnumerable<Models.Category> categories;
        public IndexModel(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task OnGet()
        {
            categories = await DataContext.categories.ToListAsync();
        }
        public async Task OnPost(Models.Category category)
        {
            DataContext.categories.Add(category);
            await DataContext.SaveChangesAsync();
        }
        public async Task OnPatch()
        {
            
        }
    }
}
