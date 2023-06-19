namespace PizzaExpress.Models;

public abstract class Product : DbEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImgUrl { get; set; }
}
