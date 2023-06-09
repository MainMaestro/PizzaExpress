namespace PizzaExpress.Models;

public class Cart:DbEntity
{
    public User User { get; set; }
    public int UserId { get; set; }
}
