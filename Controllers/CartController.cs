using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOfManyThings.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOfManyThings.Controllers;

[Route("cart")]
[Authorize]
public class CartController : Controller
{
    private readonly IRepository _repository;
    private readonly UserManager<User> _userManager;

    public CartController(IRepository repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.Users
            .Include(u => u.Cart)
            .ThenInclude(c => c.CartProducts)
            .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        if (user == null) return Challenge();

        var cartProducts = user.Cart?.CartProducts ?? new List<CartProduct>();
        return View(cartProducts);
    }

    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int productId)
    {
        var user = await _userManager.Users
            .Include(u => u.Cart)
            .ThenInclude(c => c.CartProducts)
            .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        if (user?.Cart == null) return NotFound();

        var item = user.Cart.CartProducts.FirstOrDefault(p => p.ProductId == productId);
        if (item != null)
        {
            user.Cart.CartProducts.Remove(item);
            await _repository.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}
