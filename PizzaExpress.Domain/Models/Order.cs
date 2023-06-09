namespace PizzaExpress.Models;

public class Order : DbEntity
{
    public Decimal OrderAmmount { get; set; }
    public DateTime CreationDate { get; set; }
    public User User{ get; set; }
    public int UserId{ get; set; }
}
