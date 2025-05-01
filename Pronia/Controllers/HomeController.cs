using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModels;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()

        {
           

            HomeVM homevm = new HomeVM
            {
                Slides = _context.Slides.OrderBy(s=>s.Order).Take(2).ToList(),
                
                Products = _context.Product.Include(p => p.ProductImages.Where(pi=>pi.IsPrimary!=null)).AsEnumerable().Take(6).ToList()

               
            };

            return View(homevm);
        }
    }
}
