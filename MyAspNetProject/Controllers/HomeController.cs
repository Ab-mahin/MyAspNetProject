using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyAspNetProject.Models;

namespace MyAspNetProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public string Index(Employee employee)
    {
        return "Name " + employee.Name + " ,Gender " + employee.Gender + " ,Age " + employee.Age + " ,Salary " + employee.Salary + " ,Department " + employee.Description;
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
}