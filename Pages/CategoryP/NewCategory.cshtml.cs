using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.CategoryP
{
    public class NewCategoryModel : PageModel
    {
        private readonly DataContext dataContext;
        public Category Category { get; set; }

        public NewCategoryModel( DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public void OnGet() { 
        }
        public async Task<IActionResult> OnPost(Category Category)
        {
            
            if((Category.Name != null) && ModelState.IsValid)
            {
                var name = Category.Name;
                await dataContext.categories.AddAsync(Category);
                await dataContext.SaveChangesAsync();
                TempData["Success"] = $"{Category.Name}  Created Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["Error"] = $"Category could no be added, Check that the name is not empty";
                return Page();
            }
              

        }
    }
}
