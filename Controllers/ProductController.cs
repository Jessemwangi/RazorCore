using Microsoft.AspNetCore.Mvc;

namespace RazorCore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
