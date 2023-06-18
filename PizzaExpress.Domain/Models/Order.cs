namespace PizzaExpress.Models;

public class Order : DbEntity
{
    public ICollection<OrderItem> Items { get; set; }
    public decimal OrderAmount => Items?.Sum(item => item.Product.Price * item.Quantity) ?? 0;
    public DateTime CreationDate { get; set; }
    public User User{ get; set; }
    public string UserId{ get; set; }
}
