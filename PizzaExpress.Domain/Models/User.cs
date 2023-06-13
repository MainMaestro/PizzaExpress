using Microsoft.AspNetCore.Identity;

namespace PizzaExpress.Models;

public class User : IdentityUser
{
    public String LastName { get; set; }
    public String Name { get; set; }
    public String Address { get; set; }
}
