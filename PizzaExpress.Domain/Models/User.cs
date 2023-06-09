namespace PizzaExpress.Models;

public class User : DbEntity
{
    public String LastName { get; set; }
    public String Name { get; set; }
    public String Email { get; set; }
    public String PhoneNumber { get; set; }
    public String Address { get; set; }
    public String Password { get; set; }
}
