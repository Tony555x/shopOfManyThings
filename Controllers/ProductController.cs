using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOfManyThings.Data.Models;
using ShopOfManyThings.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfManyThings.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository _repository;
        private readonly UserManager<User> _userManager;

        public ProductController(IRepository repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = (await _repository.GetAllAsync<Product>())
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

        [Route("Product/Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = (await _repository.GetAllAsync<Product>())
                .Where(p => p.Id == id)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category,
                    Description = p.Description
                })
                .FirstOrDefault();

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost("add/{id}")]
        public async Task<IActionResult> AddToCart(int id, int count)
        {
            if (count < 1) return RedirectToAction("Details", new { id });

            var user = await _userManager.Users
                .Include(u => u.Cart)
                .ThenInclude(c => c.CartProducts)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (user == null) return Challenge();

            if (user.Cart == null)
            {
                user.Cart = new Cart { UserId = user.Id };
                await _repository.AddAsync(user.Cart);
                await _repository.SaveChangesAsync();
            }

            var existing = user.Cart.CartProducts.FirstOrDefault(cp => cp.ProductId == id);
            if (existing != null)
            {
                existing.Count += count;
            }
            else
            {
                user.Cart.CartProducts.Add(new CartProduct
                {
                    CartId = user.Cart.Id,
                    ProductId = id,
                    Count = count
                });
            }

            await _repository.SaveChangesAsync();

            return RedirectToAction("Index", "Cart");
        }
    }
}
