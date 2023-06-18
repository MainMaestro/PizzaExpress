using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PizzaExpress.Mvc.Managers;
using PizzaExpress.Mvc.Interfaces.Managers;

namespace PizzaExpress.Mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IOrderManager _orderManager;

        public CartController(ICartManager cartManager, IOrderManager orderManager)
        {
            _cartManager = cartManager;
            _orderManager = orderManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var cart = _cartManager.GetCart(User);
            return View(cart);
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> CreateOrder()
        {
            await _orderManager.CreateOrder(User);
            return RedirectToAction("Index");
        }
        [HttpPost, Authorize]
        public IActionResult AddItem(string productId)
        {
            _cartManager.AddProduct(User, productId);
            return RedirectToAction("Index");
        }
        [HttpPost, Authorize]
        public IActionResult RemoveItem(string productId)
        {
            _cartManager.RemoveProduct(User, productId);
            return RedirectToAction("Index");
        }
    }
}
