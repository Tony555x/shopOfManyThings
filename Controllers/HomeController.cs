using Microsoft.AspNetCore.Mvc;
using ShopOfManyThings.Data.Models;
using ShopOfManyThings.Models;
using ShopOfManyThings.Data;

namespace ShopOfManyThings.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var products = (await _repository.GetAllAsync<Product>())
                .OrderByDescending(p => p.Price)
                .Take(4)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category,
                    Description = p.Description
                })
                .ToList();

            return View(products);
        }

        public IActionResult About() => View();
    }
}
