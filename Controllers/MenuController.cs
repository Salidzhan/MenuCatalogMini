using MenuCatalogMini.Data;
using MenuCatalogMini.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MenuCatalogMini.Controllers;
public class MenuController : Controller
{
    private readonly MenuDbContext _db;
    public MenuController(MenuDbContext db) => _db = db;
    private readonly string[] _categories = { "Салати", "Предястия", "Супи", "Основни ястия", "Десерти", "Напитки" };
    public async Task<IActionResult> Index(string? search, string? category)
    {
        var query = _db.MenuItems.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(search)) query = query.Where(x => x.Name.Contains(search));
        if (!string.IsNullOrWhiteSpace(category)) query = query.Where(x => x.Category == category);
        ViewBag.Search = search; ViewBag.Category = category; ViewBag.Categories = _categories;
        return View(await query.OrderBy(x => x.Name).ToListAsync());
    }
    public async Task<IActionResult> Details(int id) { var item=await _db.MenuItems.FindAsync(id); return item == null ? NotFound() : View(item); }
    public IActionResult Create() { ViewBag.Categories=_categories; return View(new MenuItem()); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MenuItem item) { ValidateCategory(item); if(!ModelState.IsValid){ViewBag.Categories=_categories;return View(item);} _db.Add(item); await _db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item=await _db.MenuItems.FindAsync(id); if(item==null)return NotFound(); ViewBag.Categories=_categories; return View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MenuItem item) { if(id!=item.Id)return NotFound(); ValidateCategory(item); if(!ModelState.IsValid){ViewBag.Categories=_categories;return View(item);} _db.Update(item); await _db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) { var item=await _db.MenuItems.FindAsync(id); return item==null?NotFound():View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item=await _db.MenuItems.FindAsync(id); if(item!=null){_db.Remove(item);await _db.SaveChangesAsync();} return RedirectToAction(nameof(Index)); }
    private void ValidateCategory(MenuItem item) { if(!_categories.Contains(item.Category)) ModelState.AddModelError(nameof(item.Category), "Изберете категория от списъка."); }
}
