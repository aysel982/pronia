using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModels;

namespace Pronia.Controllers
{
    public class ShopController1 : Controller
    {
        public readonly AppDbContext _context;
        public ShopController1(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id is null || id <= 0)
            { 
            return BadRequest();
            }
            Product? product = _context.Product.Include
                (p=>p.ProductImages
                .OrderByDescending(pi=>pi.IsPrimary))
                .Include(p=>p.Category)
                .FirstOrDefault(p => p.id == id);
            if (product is null)
            {
                return NotFound();
            }
            DetailVM detailvm = new DetailVM
            {
                Product = product,
                RealtedProducts = _context.Product
                .Where(p => p.CategoryId == product.CategoryId && p.id != product.id)
                .Take(8)
                .Include(p=>p.ProductImages
                .Where(pi=>pi.IsPrimary!=null))
                .ToList()
            };
            return View(detailvm);
        }
    }
}
