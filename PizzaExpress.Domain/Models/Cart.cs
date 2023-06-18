namespace PizzaExpress.Models;

public class Cart : DbEntity
{
    public User User { get; set; }
    public string UserId { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
