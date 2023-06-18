using PizzaExpress.Models;

namespace PizzaExpress.Mvc.Interfaces.Managers;

public interface IProductManager
{
    Task<Products?> GetProduct(string id, CancellationToken cancellationToken = default); 
}
