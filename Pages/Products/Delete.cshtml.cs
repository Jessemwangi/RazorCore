using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages.Products
{
    [BindProperties]
    public class DeleteProductModel : PageModel
    {
        private readonly DataContext Context;
        public IEnumerable<Category> Categories { get; set; }
        //[BindProperty]
        public Product Product { get; set; }
        public DeleteProductModel(DataContext dataContext)
        {
            Context = dataContext;
        }

        public void OnGet(long Id)
        {
            Product = Context.products.Include(p => p.Category).FirstOrDefault(p => p.Id.Equals(Id)) ?? new Product();
            //Product = Context.products.Include(p => p.Category).Where(p => p.Id.Equals(Id)).FirstOrDefault();
            Categories = Context.categories;
        }

        public async Task<IActionResult> OnPost() // bind property take care of passing model
        {

            if (!ModelState.IsValid || Product == null)
            {
                TempData["Error"] = $"Bad entry or incorrect entry.";
                return BadRequest(ModelState);
            }
            else
            {
                
                var DbProduct = Context.products?.Find(Product.Id);
                if (DbProduct != null)
                {
                    Context.products?.Remove(DbProduct);
                    await Context.SaveChangesAsync();
                    TempData["Success"] = $"{Product.Name}  Deleted";
                    return RedirectToPage("Index");
                }
                else
                {
                    TempData["Error"] = $"Failed to delete {Product.Name}.";
                    return BadRequest("No Record found");
                }
            }




        }
    }
}
