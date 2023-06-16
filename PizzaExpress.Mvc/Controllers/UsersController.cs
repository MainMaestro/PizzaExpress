using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaExpress.Models;
using PizzaExpress.Mvc.ViewModels;

namespace PizzaExpress.Mvc.Controllers;

public class UsersController : Controller
{
    const string DefaultPassword = "Admin111!";
    private readonly SignInManager<User> _signIn;

    public UsersController(SignInManager<User> signIn)
    {
        _signIn = signIn;
    }
   
    [HttpPost]
    public async Task<IActionResult> Login([Bind] LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return Redirect(model.ReturnUrl);
        }
        var user = await _signIn.UserManager.Users
            .FirstOrDefaultAsync(user => user.PhoneNumber == model.PhoneNumber);
        if (user is null)
        {
            user = new User
            {
                Name = model.PhoneNumber,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = true
            };

            await _signIn.UserManager.CreateAsync(user, DefaultPassword);
        }

        await _signIn.PasswordSignInAsync(user, DefaultPassword, model.Remember, false);
        return Redirect(model.ReturnUrl);
    }
}
