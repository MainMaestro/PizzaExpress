namespace PizzaExpress.Models;

public class Product : DbEntity
{
    public String Name { get; set; }
    public String Description { get; set; }
    public Decimal Price { get; set; }
}
