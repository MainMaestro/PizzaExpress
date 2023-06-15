using System.ComponentModel.DataAnnotations;

namespace PizzaExpress.Mvc.ViewModels;

public class LoginViewModel
{
    public string ReturnUrl { get; set; } = "";
    [Required, Phone]
    public string PhoneNumber { get; set; }
    [Required]
    public bool Remember { get; set; } = false;
}
