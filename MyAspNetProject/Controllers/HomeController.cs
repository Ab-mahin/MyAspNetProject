using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Models;

namespace MyAspNetProject.Controllers;

public class HomeController : Controller
{
    private readonly EmployeeDbContext _employeeDb;
    // private readonly ILogger<HomeController> _logger;
    //
    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public HomeController(EmployeeDbContext employeeDb)
    {
        _employeeDb = employeeDb;
    }

    public async Task<IActionResult> Index()
    {
        var stdData =  await _employeeDb.Employees.ToListAsync();
        return View(stdData); 
    }
    
    
    
    public IActionResult Create()
    {
        return  View(); 
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Employee emp)
    {
        if (ModelState.IsValid)
        {
            await _employeeDb.Employees.AddAsync(emp);
            await _employeeDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return  View(emp); 
    }
    
    
    public async Task<IActionResult> Details(int id)
    {
        var stdData =  await _employeeDb.Employees.FirstOrDefaultAsync(x => x.Id == id);
        return View(stdData); 
    }
    
    // [HttpPost]
    // public string Index(Employee employee)
    // {
    //     return "Name " + employee.Name + " ,Gender " + employee.Gender + " ,Age " + employee.Age + " ,Salary " + employee.Salary + " ,Department " + employee.Description;
    // }
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