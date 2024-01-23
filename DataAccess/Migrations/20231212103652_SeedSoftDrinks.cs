using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedSoftDrinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\n\tVALUES\r\n    ('Göttiga Citrusspraket', 'En ruggigt gött läskedryck me smak av citrus o bubblor.', 25.99, 0, 0, 0, 0, 0, 'assets/img/GöttigaCitrusspraket.jpg'),\r\n    ('Bubblig Bärnrajs', 'En saftig bärsmakad läskedryck me bubblande bubblor.', 22.50, 0, 0, 0, 0, 0,'assets/img/BubbligBärnrajs.jpg'),\r\n    ('Zero Sugar Cola', 'Gammaldags colasmak uta tillsatt socker, perfekt för di som håller koll på sockerintaget.', 18.75, 0, 0, 0, 0, 0, 'assets/img/ZeroSugarCola.jpg'),\r\n    ('Koffeinfri Citronad Skval', 'En riktigt gött koffeinfri citronad me ett skvätta citronsmak.', 20.25, 0, 0, 0, 0, 0, 'assets/img/KoffeinfriCitronadSkval.jpg'),\r\n    ('Ingefärs Njutning', 'En lugnande ingefärsdusch me en touch av sötma o bubblor.', 19.99, 0, 0, 0, 0, 0, 'assets/img/IngefärsNjutning.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
