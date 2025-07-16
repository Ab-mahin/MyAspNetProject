using Microsoft.EntityFrameworkCore;
using AspCRUD.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    
builder.Services.AddControllersWithViews();

// Db Services add
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<EmployeeDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// docker rm ms-sql-server
// docker run -d --name ms-sql-server -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyDocker@123" -p 1433:1433 mcr.microsoft.com/azure-sql-edge:latest
