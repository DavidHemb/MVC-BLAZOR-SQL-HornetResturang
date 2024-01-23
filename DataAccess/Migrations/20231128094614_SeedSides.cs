using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedSides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\nVALUES\r\n  ('Kladdkakskrispiga Kryddnötter', 'Rostade nötter insvepta i en kladdig choklad- och kakaoströssel, med en hint av kanel och socker.', 39.90, 0, 0, 0, 1, 0, 'assets/img/Kladdkakskrispiga-Kryddnötter.jpg'),\r\n  ('Flottiga Ostbollar', 'Ostbollar doppade i smält smör och rullade i en mix av smulig bacon och ostflingor.', 49.90, 0, 0, 0, 0, 0, 'assets/img/Flottiga-Ostbollar.jpg'),\r\n  ('Krispiga Krispsmörvar', 'Potatischips överströsslade med smält smör och smörkryddat popcorn, för en dubbel dos av smörigt nöje.', 29.90, 0, 0, 0, 0, 0, 'assets/img/Krispiga-Krispsmörvar.jpg'),\r\n  ('Saltlakrits-Sirapspopcorn', 'Popcorn dränkta i saltlakritssirap och toppade med smågodisbitar för en explosiv söt-och-salt smakupplevelse.', 45.90, 0, 0, 0, 1, 0, 'assets/img/Saltlakrits-Sirapspopcorn.jpg'),\r\n  ('Chokladövertäckta Ostbågar', 'Ostbågar dränkta i mörk choklad och pudrade med florsocker, för den ultimata kontrasten mellan salt och sött.', 59.90, 0, 0, 0, 0, 0, 'assets/img/Chokladövertäckta-Ostbågar.jpg'),\r\n  ('Sockerstinna Salta Spretbönor', 'Spretiga gröna bönor doppade i sockerlag och rullade i krossade salta kex, för en konstig men beroendeframkallande smakkombination.', 34.90, 0, 0, 0, 0, 0, 'assets/img/Sockerstinna-Salta-Spretbönor.jpg'),\r\n  ('Snaskiga Sillchips', 'Lättsaltade chips med en sälta av inlagd sill och en touch av syrlig gräddfil, för den ultimata smöriga och havsiga crunchen.', 42.90, 0, 0, 0, 0, 0, 'assets/img/Snaskiga-Sillchips.jpg'),\r\n  ('Chokladpuffade Pretzelknyten', 'Pretzelknyten överdragna med mörk choklad och puffade rispuffar, för en krispig och chokladig snacksensation.', 55.90, 0, 0, 0, 0, 0, 'assets/img/Chokladpuffade-Pretzelknyten.jpg'),\r\n  ('Lökpulverdränkta Läskiga Lakritsbitar', 'Lakritsbitar doppade i lökpulver för en överraskande och tårdrypande smakupplevelse.', 38.90, 0, 0, 0, 0, 0, 'assets/img/Lökpulverdränkta-Läskiga-Lakritsbitar.jpg'),\r\n  ('Bubblig Blandning av Buggchips', 'Chips kryddade med en bubblig blandning av söta och kolsyrehaltiga läskedrycker, för den ultimata snacksfestivalen.', 44.90, 0, 0, 0, 0, 0, 'assets/img/Bubblig-Blandning-Buggchips.jpg')INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\n\tVALUES \r\n\t\t('Bubbens kokbok', 'Bubben eller Morran från tv serien Morran och Tobias egna kokbok (Bubbens egna citat kring boken: Alla andra maträtter i kokböker saknar nikotin eller bensin de gör bannemig inte min serru).', 2599, 0, 0, 0, 0, 0, 'assets/img/BubbensKokbok.jpg')\r\n\r\n\tINSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\n\tVALUES \r\n\t\t('HÖRNET TSHIRT MERCH', 'Storlek(S). Beställningsvara, leveranstid ca 32 veckor. Kravmärkta produkter. Made in Indian sweetshops by kinda well paid somewhat adults. 100% not organic cotton, dont let it touch your skin. Wear whit pride(not gay pride(unless you want it to be(then it most defenitly is)))!', 799, 0, 0, 0, 0, 0, 'assets/img/Hörnettshirt.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
