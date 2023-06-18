using Microsoft.EntityFrameworkCore;
using PizzaExpress.Models;
using PizzaExpress.Mvc.Data;
using PizzaExpress.Mvc.Interfaces.Managers;

namespace PizzaExpress.Mvc.Managers;

public class ProductManager : IProductManager
{
	private readonly ApplicationDbContext _context;

	public ProductManager(ApplicationDbContext context)
    {
		_context = context;
	}
    public async Task<Products?> GetProduct(string id, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _context.Products
			.FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
	}
}
