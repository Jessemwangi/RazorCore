using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Models;

namespace RazorCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext DataContext;
        public IEnumerable<Product> Products;

        public IndexModel(ILogger<IndexModel> logger, DataContext _dataContext)
        {
            _logger = logger;
            DataContext = _dataContext;
        }

        public async Task OnGetAsync()
        {
            Products = await DataContext.products.Include(p => p.Category).ToListAsync();
        }
    }
}