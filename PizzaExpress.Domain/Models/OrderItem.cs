namespace PizzaExpress.Models;

public class OrderItem : DbEntity
{
    public int Quantity { get; set; }
    public Product Product{ get; set; }
    public int ProductId{ get; set; }
}
