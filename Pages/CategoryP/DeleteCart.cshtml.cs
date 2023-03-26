using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.CategoryP
{
    public class DeleteCartModel : PageModel
    {
        public Category category { get; set; }
        private readonly DataContext DataContext;
        public DeleteCartModel(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public async Task<IActionResult> OnGetAsync(long Id)
        {
            category = await DataContext.categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == Id);
            if (category == null)
            {
                TempData["Error"] = $"Category with ID {Id} not found.";
                return RedirectToPage("Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(long Id)
        {
            try
            {
                category = await DataContext.categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == Id);
                if (category == null)
                {
                    TempData["Error"] = $"Category with ID {Id} not found.";
                    return RedirectToPage("Index");
                }

                if (category.Products.Any())
                {
                    TempData["Error"] = $"Cannot delete category '{category.Name}' because it has associated products.";
                    return RedirectToPage("Index");
                }

                DataContext.categories.Remove(category);
                await DataContext.SaveChangesAsync();

                TempData["Success"] = $"Category '{category.Name}' deleted.";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred while deleting the category. Please try again later. Error : {ex.Message}";
                return RedirectToPage("Index");
            }
        }
    }

}
