using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaExpress.Models;
using PizzaExpress.Mvc.Data;
using PizzaExpress.Mvc.Interfaces.Managers;

namespace PizzaExpress.Mvc.Managers;

public class CartManager : ICartManager
{
	private readonly ApplicationDbContext _context;
	private readonly UserManager<User> _userManager;
	private readonly IProductManager _productManager;

	public CartManager(ApplicationDbContext context, UserManager<User> userManager, IProductManager productManager)
	{
		_context = context;
		_userManager = userManager;
		_productManager = productManager;
	}
	public Cart GetCart(ClaimsPrincipal user)
	{
		var userId = GetUserId(user);
		var cart = _context.Carts
			.Include(c => c.Items)
			.ThenInclude(c => c.Product)
			.FirstOrDefault(c => c.UserId == userId) 
			?? Create(userId);

		return cart;
	}
	public async Task<Cart> GetCart(ClaimsPrincipal user, CancellationToken cancellationToken = default)
	{
		var userId = GetUserId(user);
		var cart = await _context.Carts
			.Include(c => c.Items)
			.ThenInclude(c => c.Product)
			.FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken) ?? Create(userId);

		return cart;
	}
	public async Task<Cart> AddProduct(ClaimsPrincipal user, string productId, CancellationToken cancellationToken = default)
	{
		var product = await _productManager.GetProduct(productId, cancellationToken);

		if (product is null)
			return GetCart(user);

		return AddProduct(user, product);
	}
	public async Task<Cart> RemoveProduct(ClaimsPrincipal user, string productId, CancellationToken cancellationToken = default)
	{
		var product = await _productManager.GetProduct(productId, cancellationToken);
	
		if (product is null)
			return GetCart(user);

		return RemoveProduct(user, product);
	}
	private Cart Create(string userId)
	{
		var cart = new Cart { UserId = userId };
		_context.Carts.Add(cart);
		_context.SaveChanges();
		return cart;
	}
	private Cart AddProduct(ClaimsPrincipal user, Product product)
	{
		var cart = GetCart(user);

		var currentItem = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);

		if (currentItem is not null)
			currentItem.Quantity++;
		else
			cart.Items.Add(new OrderItem { Product = product, Quantity = 1 });

		_context.Carts.Update(cart);
		_context.SaveChanges();

		return cart;
	}
	
	private Cart RemoveProduct(ClaimsPrincipal user, Product product)
	{
		var cart = GetCart(user);

		var currentItem = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);
		if (currentItem is not null)
		{
			currentItem.Quantity--;
			if (currentItem.Quantity <= 0)
				cart.Items.Remove(currentItem);
		}

		_context.Carts.Update(cart);
		_context.SaveChanges();

		return cart;
	}
	
	private string GetUserId(ClaimsPrincipal user)
	{
		return _userManager.GetUserId(user) ?? throw new Exception("User not authorized");
	}

	public async Task<Cart> ClearCart(ClaimsPrincipal user, CancellationToken cancellationToken = default)
	{
		var cart = GetCart(user);
		cart.Items = new List<OrderItem>();

		_context.Carts.Update(cart);
		await _context.SaveChangesAsync(cancellationToken);
		return cart;
	}
}