namespace PizzaExpress.Models;

public class Pizza : DbEntity
{
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public int Diameter { get; set; }
    public String Ingredients { get; set; }
}
