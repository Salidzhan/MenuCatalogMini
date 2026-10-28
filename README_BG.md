# MenuCatalogMini — ASP.NET Core MVC (.NET 8)

## Отваряне във Visual Studio 2022
1. Разархивирайте архива в папка.
2. Отворете `MenuCatalogMini.sln` от главната папка.
3. Изчакайте Visual Studio да възстанови NuGet пакетите.
4. Изберете `MenuCatalogMini` като Startup Project, ако не е избран автоматично.
5. Натиснете F5.

## Структура
- `MenuCatalogMini.sln` и `MenuCatalogMini.csproj` са в една и съща главна папка.
- `Controllers/MenuController.cs`
- `Models/MenuItem.cs`
- `Data/MenuDbContext.cs`
- `Views/Menu/` и `Views/Shared/`
- `wwwroot/css/site.css`

## Изисквания
- Visual Studio 2022 с workload „ASP.NET and web development“
- .NET 8 SDK
- SQL Server LocalDB (включен обикновено с Visual Studio)

Приложението използва SQL Server LocalDB и създава базата при първо стартиране.
