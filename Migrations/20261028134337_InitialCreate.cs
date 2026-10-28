using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MenuCatalogMini.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Grams = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Grams", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Салати", "Домати, краставици, сирене, чушки и магданоз.", 300, "Шопска салата", 7.50m },
                    { 2, "Супи", "Топла супа с пилешко месо и зеленчуци.", 350, "Пилешка супа", 5.20m },
                    { 3, "Основни ястия", "Пилешко филе с печени картофи.", 450, "Пилешка пържола с картофи", 14.90m },
                    { 4, "Десерти", "Шоколадов десерт с какаов крем.", 150, "Шоколадова торта", 6.40m },
                    { 5, "Напитки", "Освежаваща домашна лимонада.", 250, "Лимонада", 3.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
