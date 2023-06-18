namespace PizzaExpress.Models;

public class OrderItem : DbEntity
{
	public Product Product { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; }
}
