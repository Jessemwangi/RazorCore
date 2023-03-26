using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.CategoryP
{
    public class EditCartModel : PageModel
    {
        Category category { get; set; }
        private readonly DataContext dataContext;

        public EditCartModel( DataContext DataContext)
        {
           
            dataContext = DataContext;
        }
    
        public async Task OnGet(long Id)
        {
            category = await dataContext.categories.FindAsync(Id);
        }
    }
}
