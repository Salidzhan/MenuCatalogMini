using MenuCatalogMini.Models;
using Microsoft.EntityFrameworkCore;
namespace MenuCatalogMini.Data;
public class MenuDbContext : DbContext
{
    public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { }
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MenuItem>().Property(x => x.Price).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id=1, Name="Шопска салата", Category="Салати", Price=7.50m, Grams=300, Description="Домати, краставици, сирене, чушки и магданоз." },
            new MenuItem { Id=2, Name="Пилешка супа", Category="Супи", Price=5.20m, Grams=350, Description="Топла супа с пилешко месо и зеленчуци." },
            new MenuItem { Id=3, Name="Пилешка пържола с картофи", Category="Основни ястия", Price=14.90m, Grams=450, Description="Пилешко филе с печени картофи." },
            new MenuItem { Id=4, Name="Шоколадова торта", Category="Десерти", Price=6.40m, Grams=150, Description="Шоколадов десерт с какаов крем." },
            new MenuItem { Id=5, Name="Лимонада", Category="Напитки", Price=3.50m, Grams=250, Description="Освежаваща домашна лимонада." }
        );
    }
}
