using Microsoft.AspNetCore.Mvc;

namespace PizzaExpress.Mvc.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult _UserPartial()
        {
            return View();
        }
    }
}
