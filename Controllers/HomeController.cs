using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOfManyThings.Data;
using ShopOfManyThings.Models;

namespace ShopOfManyThings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .OrderByDescending(p => p.Price) // mock "popularity"
                .Take(4)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category,
                    Description = p.Description
                })
                .ToListAsync();

            return View(products);
        }
        public IActionResult About() => View();
    }
}
