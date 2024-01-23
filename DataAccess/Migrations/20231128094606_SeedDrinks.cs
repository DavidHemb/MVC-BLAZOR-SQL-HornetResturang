using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDrinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\nVALUES\r\n  ('Frossar-Fizz', 'En explosiv blandning av sockerstinna läskedrycker, toppad med fluffig vispgrädde och överströsslad med smågodis.', 59, 10.0,  0, 0, 0, 0, 'assets/img/Frozzar-fizzz.jpg'),\r\n  ('Slemmig Sockershocktail', 'En bländande färgglad cocktail av sockersöta likörer, serverad i ett kladdigt sockerrimmat glas.', 79, 15.0, 0, 0, 0, 0, 'assets/img/Slemmig-sockershocktail.jpg'),\r\n  ('Griniga Gröten-Grogg', 'En värmande blandning av havregrynssprit, kanelvodka och gräddig mjölk, toppad med en klick smör.', 89, 20.0, 0, 1, 0, 0, 'assets/img/Griniga-gröten-grogg.jpg'),\r\n  ('Snaskiga Smultronskakern', 'En fruktig mix av smultronlikör, vaniljvodka och en touch av skvalande smält glass.', 69, 18.0, 0, 0, 0, 0, 'assets/img/Snaskiga-Smultronskakern.jpg'),\r\n  ('Rödvinsrännstens-Razzia', 'En robust blandning av billig rödvin, cola och en skvätt tequila - serverad i en plastmugg för den autentiska känslan.', 49, 12.0, 0, 0, 0, 0, 'assets/img/rödvinsrännstens.jpg'),\r\n  ('Kladdkaka-Kaskad', 'En chokladig kaskad av Baileys, chokladlikör och överdådig chokladsås, garnerad med smulig kladdkaka.', 99, 15.0, 0, 0, 0, 0, 'assets/img/kladdkaka-kaskad.jpg'),\r\n  ('Skumma Skrubbsoda', 'En överraskande bubblig mix av citronvodka, tandläkarens favoritläsk och en citronskiva som förlåtelse.', 79, 14.0, 0, 0, 0, 0, 'assets/img/Skumma-Skrubbsoda.jpg'),\r\n  ('Bråkig Blåbärsbläckpatrull', 'En skarp blandning av blåbärslikör, gin och ett stänk av bläck från fiskstimuleringssprutan.', 89, 22.0, 0, 0, 0, 0, 'assets/img/bråkig-blåbärsbläckpatrull.jpg'),\r\n  ('Krämig Karamellkaos', 'En krämig cocktail av karamellvodka, kolasnaps och en kolasåsrand, serverad med extra sötsliskiga kolor.', 109, 16.0, 0, 0, 0, 0, 'assets/img/Krämig-Karamellkaos.jpg'),\r\n  ('Suröls-Snuttarita', 'En sur twist på en klassisk margarita, med en touch av suröl och en saltkant av krossade surisar.', 69, 14.0, 0, 0, 0, 0, 'assets/img/suröls-snuttarita.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
