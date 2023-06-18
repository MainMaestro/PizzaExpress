using System.Security.Claims;
using PizzaExpress.Models;

namespace PizzaExpress.Mvc.Interfaces.Managers;

public interface IOrderManager
{
	Task CreateOrder(ClaimsPrincipal user, CancellationToken cancellationToken = default);
	Task<IEnumerable<Order>> GetOrders(ClaimsPrincipal user, CancellationToken cancellationToken = default);
}
