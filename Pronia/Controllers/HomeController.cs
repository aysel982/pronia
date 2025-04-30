using Microsoft.AspNetCore.Mvc;
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
            Product product = new Product();
            Category category = new Category();


            //List<Slide> slides = new List<Slide>
            //{
            //new Slide
            //{
            //    id=1,
            //    Title="guller",
            //    Subtitle="25% endirim",
            //    Description="made with love",
            //    Order=1,
            //    Image="oıp.jfif",
            //    CreatedAt=DateTime.Now
            //},
            //new Slide
            //{
            //    id=1,
            //    Title="corsage",
            //    Subtitle="8 marta ozel endirim",
            //    Description="make your loved ones happy",
            //    Order=2,
            //    Image="oıp (1).jfif",
            //    CreatedAt=DateTime.Now
            //},
            //new Slide
            //{
            //    id=1,
            //    Title="flower box",
            //    Subtitle="10% endirim",
            //    Description="just for you",
            //    Order=3,
            //    Image="img/slide-1.jpg",
            //    CreatedAt=DateTime.Now
            //}
            //};

            //context.Slides.AddRange(slides);
            //context.SaveChanges();

            HomeVM homevm = new HomeVM
            {
                Slides = _context.Slides.OrderBy(s=>s.Order).Take(2).ToList(),
                Products = _context.Products.ToList()
            };

            return View(homevm);
        }
    }
}
