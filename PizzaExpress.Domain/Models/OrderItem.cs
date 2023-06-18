namespace PizzaExpress.Models;

public class OrderItem : DbEntity
{
	public Products? Product { get; set; }
	public string ProductId { get; set; }
	public int Quantity { get; set; }
}
