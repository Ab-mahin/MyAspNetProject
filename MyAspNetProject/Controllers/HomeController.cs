using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    
    
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _employeeDb.Employees.Find(id)  == null)
        {
            return NotFound();
        }
        var stdData =  await _employeeDb.Employees.FirstOrDefaultAsync(x => x.Id == id);

        if (stdData == null)
        {
            return NotFound();
        }
        
        return View(stdData); 
    }

    public async Task<IActionResult> Edit(int? id)
    {   
        if (id == null || _employeeDb.Employees.Find(id)  == null)
        {
            return NotFound();
        }
        var stdData =  await _employeeDb.Employees.FindAsync(id);
        if (stdData == null)
        {
            return NotFound();
        }
        return View(stdData);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int? id , Employee emp)
    {
        if (id != emp.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            _employeeDb.Employees.Update(emp);
            await _employeeDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(emp);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _employeeDb.Employees.Find(id)  == null)
        {
            return NotFound();
        }
        var stdData =  await _employeeDb.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (stdData == null)
        {
            return NotFound();
        }
        return View(stdData);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var stdData =  await _employeeDb.Employees.FindAsync(id);
        if (stdData != null)
        {
            _employeeDb.Employees.Remove(stdData);
        }
        await _employeeDb.SaveChangesAsync();
        return RedirectToAction("Index");
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