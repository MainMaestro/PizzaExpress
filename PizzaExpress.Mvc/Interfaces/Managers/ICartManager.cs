using System.Security.Claims;
using PizzaExpress.Models;

namespace PizzaExpress.Mvc.Interfaces.Managers;

public interface ICartManager
{
    Cart GetCart(ClaimsPrincipal user);
    Task<Cart> GetCart(ClaimsPrincipal user, CancellationToken cancellationToken = default);
    Task<Cart> ClearCart(ClaimsPrincipal user, CancellationToken cancellationToken = default);
    Task<Cart> AddProduct(ClaimsPrincipal user, string productId, CancellationToken cancellationToken = default);
    Task<Cart> RemoveProduct(ClaimsPrincipal user, string productId, CancellationToken cancellationToken = default);
}
