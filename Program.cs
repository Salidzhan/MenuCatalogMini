using MenuCatalogMini.Data;
using MenuCatalogMini.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Create the database on first run and insert sample menu items.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MenuDbContext>();
    db.Database.EnsureCreated();

    if (!db.MenuItems.Any())
    {
        db.MenuItems.AddRange(
            new MenuItem { Name = "Шопска салата", Category = "Салати", Price = 7.50m, Grams = 300, Description = "Домати, краставици, сирене, чушки и магданоз." },
            new MenuItem { Name = "Пилешка супа", Category = "Супи", Price = 5.20m, Grams = 350, Description = "Топла супа с пилешко месо и зеленчуци." },
            new MenuItem { Name = "Пилешка пържола с картофи", Category = "Основни ястия", Price = 14.90m, Grams = 450, Description = "Пилешко филе с печени картофи." },
            new MenuItem { Name = "Шоколадова торта", Category = "Десерти", Price = 6.40m, Grams = 150, Description = "Шоколадов десерт с какаов крем." },
            new MenuItem { Name = "Лимонада", Category = "Напитки", Price = 3.50m, Grams = 250, Description = "Освежаваща домашна лимонада." }
        );
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Menu/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Menu}/{action=Index}/{id?}");
app.Run();
