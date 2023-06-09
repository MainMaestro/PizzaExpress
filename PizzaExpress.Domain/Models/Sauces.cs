namespace PizzaExpress.Models;

public class Sauces : DbEntity
{
    public Product Product { get; set; }
    public int ProductId { get; set; }
}
