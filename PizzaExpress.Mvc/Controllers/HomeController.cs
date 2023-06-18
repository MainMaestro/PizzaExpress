using Microsoft.AspNetCore.Mvc;
using PizzaExpress.Mvc.Data;
using PizzaExpress.Mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace PizzaExpress.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        this.context = context;
    }

   

    public IActionResult Index(string id)
    {
        var products = context.Products.Where(c => c.Id == id).ToArray();
      
       
        return View();
       
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Franshiza()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    } 
    public IActionResult Sotrudnichestvo()
    {
        return View();
    }
    public IActionResult Restaurants()
    {
        return View();
    }
    public IActionResult Profile()
    {
        return View();
    } 
    public IActionResult Orders()
    {
        return View();
    }
}