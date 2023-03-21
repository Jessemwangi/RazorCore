using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.Products
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly DataContext Context;
        public IEnumerable<Category> Categories { get; set; }
        //[BindProperty]
        public Product Product { get; set; }
        public CreateModel(DataContext dataContext)
        {
            Context = dataContext; 
        }

        public void OnGet()
        {
            Categories = Context.categories;
        }
        public async Task<IActionResult> OnPost() // bind property take care of passing model
        {
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
                await Context.products.AddAsync(Product);
                await Context.SaveChangesAsync();
                TempData["Success"] =$"{ Product.Name}  Created Successfully";
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
