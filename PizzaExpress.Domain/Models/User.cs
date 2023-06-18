using Microsoft.AspNetCore.Identity;

namespace PizzaExpress.Models;

public class User : IdentityUser
{
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
