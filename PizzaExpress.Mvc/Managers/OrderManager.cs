using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PizzaExpress.Models;
using PizzaExpress.Mvc.Data;
using PizzaExpress.Mvc.Interfaces.Managers;

namespace PizzaExpress.Mvc.Managers;

public class OrderManager : IOrderManager
{
	private readonly ApplicationDbContext _context;
	private readonly ICartManager _cartStore;
	private readonly UserManager<User> _userManager;

	public OrderManager(ApplicationDbContext context, ICartManager cartStore, UserManager<User> userManager)
    {
		_context = context;
		_cartStore = cartStore;
		_userManager = userManager;
	}

	public async Task CreateOrder(ClaimsPrincipal user, CancellationToken cancellationToken = default)
	{
		var cart = await _cartStore.GetCart(user, cancellationToken);
		if (cart.Items.Count == 0)
			return;

		 var order = new Order 
		 { 
			 CreationDate = DateTime.Now,
			 Items = cart.Items,
			 UserId = GetUserId(user),
		 };
		await _cartStore.ClearCart(user, cancellationToken);

		_context.Add(order);
		await _context.SaveChangesAsync(cancellationToken);
	}
	private string GetUserId(ClaimsPrincipal user)
	{
		return _userManager.GetUserId(user) ?? throw new Exception("User not authorized");
	}
	public Task<IEnumerable<Order>> GetOrders(ClaimsPrincipal user, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}
