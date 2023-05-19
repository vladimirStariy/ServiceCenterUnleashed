using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.View;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           //.UseLazyLoadingProxies()
);
builder.Services.AddScoped<DbContext, ApplicationDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });

builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Operator",
    areaName: "Operator",
    pattern: "operator/{controller=Abonent}/{action=Abonents}/{id?}");

app.MapAreaControllerRoute(
    name: "Employee",
    areaName: "Employer",
    pattern: "employee/{controller=Abonent}/{action=Abonents}/{id?}");

app.MapAreaControllerRoute(
    name: "Guest",
    areaName: "Guest",
    pattern: "guest/{controller=Guest}/{action=Tariffs}/{id?}");

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Tariff}/{action=Tariffs}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
