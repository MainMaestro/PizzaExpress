namespace PizzaExpress.Models;

public abstract class Product : DbEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
}
