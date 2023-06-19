using PizzaExpress.Models;

namespace PizzaExpress.Mvc.Interfaces.Managers;

public interface IProductManager
{
    Task<Product?> GetProduct(string id, CancellationToken cancellationToken = default); 
}
