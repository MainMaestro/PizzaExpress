namespace PizzaExpress.Models;

public class Cart:DbEntity
{
    public User User { get; set; }
    public string UserId { get; set; }
}
