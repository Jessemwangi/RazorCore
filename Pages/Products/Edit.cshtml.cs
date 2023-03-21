using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.Products
{
    [BindProperties]
    public class EditProductModel : PageModel
    {
        private readonly DataContext Context;
        public IEnumerable<Category> Categories { get; set; }
        //[BindProperty]
        public Product Product { get; set; }
        public EditProductModel(DataContext dataContext)
        {
            Context = dataContext; 
        }

        public void OnGet(long Id)
        {
            Product = Context.products.Include(p => p.Category).FirstOrDefault(p => p.Id.Equals(Id));
            //Product = Context.products.Include(p => p.Category).Where(p => p.Id.Equals(Id)).FirstOrDefault();
            Categories = Context.categories;
        }

        public async Task<IActionResult> OnPost() // bind property take care of passing model
        {
            var p = Product;
            //if(Product != null && !string.IsNullOrEmpty(Product.Name) && Product.Name == "jesse")
            //{
            //    Product.Name += "root user";
            //}
            if (Product == null && string.IsNullOrEmpty(Product.Name))
            {
                ModelState.AddModelError("Product.Name", "Please enter a value for name");
            }
            else if (Product.CategoryId == 0)
            {
                ModelState.AddModelError("SelectError", "Please select the category");
            }
            if (ModelState.IsValid)
            {
                Context.products.Update(Product);
                await Context.SaveChangesAsync();
                TempData["Success"] = $"{Product.Name}  Updated";
                return RedirectToPage("Index");
            }
            else
            {
                Categories = Context.categories;
                return Page();
            }
        }
    }
}
