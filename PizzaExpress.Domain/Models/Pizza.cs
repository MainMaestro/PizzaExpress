namespace PizzaExpress.Models;

public class Pizza : Product
{
    public Product Product { get; set; }
    public string ProductId { get; set; }
    public int Diameter { get; set; }
    public string Ingredients { get; set; }
}
