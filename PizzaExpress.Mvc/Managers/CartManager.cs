
//using PizzaExpress.Mvc.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//using PizzaExpress.Models;

//namespace PizzaExpress.Mvc.Managers;

//    public class CartManager
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<IdentityUser> _userManager;

//        public CartManager(ApplicationDbContext context, UserManager<IdentityUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }
//        private Cart Create(string userId)
//        {
//            var cart = new Cart { UserId = userId };
//            _context.Carts.Add(cart);
//            _context.SaveChanges();
//            return cart;
//        }
//        private string GetUserId(ClaimsPrincipal user)
//        {
//            return _userManager.GetUserId(user) ?? throw new Exception("User not authorized");
//        }
//        public Cart AddProduct(ClaimsPrincipal user, Product product)
//        {
//            var userId = GetUserId(user);
//            var cart = GetCart(user);

//            var currentItem = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);

//            if (currentItem is not null)
//                currentItem.Count++;
//            else
//                cart.Items.Add(new OrderItem { Product = product, Count = 1 });

//            _context.Carts.Update(cart);
//            _context.SaveChanges();

//            return cart;
//        }
//        public Cart AddProduct(ClaimsPrincipal user, string productId)
//        {
//            var product = _context.Products.FirstOrDefault(c => c.Id == productId);

//            if (product is null)
//                return GetCart(user);

//            return AddProduct(user, product);
//        }
//        public Cart RemoveProduct(ClaimsPrincipal user, Product product)
//        {
//            var userId = GetUserId(user);
//            var cart = GetCart(user);

//            var currentItem = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);
//            if (currentItem is not null)
//            {
//                currentItem.Count--;
//                if (currentItem.Count <= 0)
//                    cart.Items.Remove(currentItem);
//            }

//            _context.Carts.Update(cart);
//            _context.SaveChanges();

//            return cart;
//        }
//        public Cart RemoveProduct(ClaimsPrincipal user, string productId)
//        {
//            var product = _context.Products.FirstOrDefault(c => c.Id == productId);

//            if (product is null)
//                return GetCart(user);

//            return RemoveProduct(user, product);
//        }
//        public Cart GetCart(ClaimsPrincipal user)
//        {
//            var userId = GetUserId(user);
//            var cart = _context.Carts
//                .Include(c => c.Items)
//                .ThenInclude(c => c.Product)
//                .FirstOrDefault(c => c.UserId == userId);

//            cart ??= Create(userId);

//            return cart;
//        }
//    }

