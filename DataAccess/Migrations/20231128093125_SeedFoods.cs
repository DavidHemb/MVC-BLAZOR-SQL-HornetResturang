using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedFoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\nVALUES \r\n\t('Fettisdubbelburgare', 'Dubbla köttburgare, extra ost, doppad i smält smör och strösslad med baconflarn.', 109, 0, 0, 0, 0, 0, '/assets/img/fettisdubbelburgare.jpg'),\r\n\t('Brödrockad Baconbomb', 'En hamburgare inlindad i friterad ost och täckt med krispigt bacon, serverad på en säng av pommes frites.', 12.99, 0, 0, 0, 0, 0, 'assets/img/brödrockad-baconbomb.jpg'),\r\n\t('Smältande Smörkalv', 'En saftig kalvburgare dränkt i smält smör, toppad med lökstrimlor och smält ost.', 119, 0, 0, 0, 0, 0, 'assets/img/Smältande-smörkalv.jpg'),\r\n\t('Kräkfräck Kycklingknyckare', 'Panerad och friterad kycklingfilé, överdränkt i krämig ranchdressing, med extra pickles.', 99, 0, 0, 1, 0, 0, 'assets/img/kräkfräck-kycklingknyckare.jpg'),\r\n\t('Flottiga Friterade Lökloopar', 'Friterade lökringar dränkta i ost- och jalapeñosås, serverade med en extra sida av fet majonnäs.', 79, 0, 0, 1, 0, 0, 'assets/img/flottiga-friterade-lökloopar.jpg'),\r\n\t('Svettig Slaskkorv Deluxe', 'En jättekorv inlindad i bacon, toppad med grillad lök, pickles och senap.', 89, 0, 0, 1, 0, 0, 'assets/img/Svettig-Slaskkorv-Deluxe.jpg'),\r\n\t('Klibbiga Kycklingnaglar', 'Heta kycklingvingar doppade i klibbig BBQ-sås, serverade med en sida av blekta selleristänger.', 99, 0, 0, 1, 0, 0, 'assets/img/Klibbiga-Kycklingnaglar.jpg'),\r\n\t('Grisgyttelicious Gräddpaj', 'En kolossal köttpaj fylld med bacon, korv, och gräddig ost, serverad med extra gräddfil.', 149, 0, 0, 1, 0, 0, 'assets/img/Grisgyttelicious-Gräddpaj.jpg'),\r\n\t('Smörig Skräpburgare', 'En blandning av diverse köttrester, överhälld med smält smör och ost, serverad i ett mosat bröd.', 139, 0, 0, 1, 0, 0, 'assets/img/Smörig-Skräpburgare.jpg'),\r\n\t('Sötsliskig Smältchoklad-Baconboll', 'En jättestor chokladboll fylld med smält marshmallow, chokladsås och krispigt bacon.', 69, 0, 1, 0, 0, 0, 'assets/img/Sötsliskig-Smältchoklad-Baconboll.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
