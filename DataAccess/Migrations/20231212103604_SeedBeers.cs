using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedBeers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Alcohol, Lactose, Gluten, Vegan, IsDeleted, ImagePath)\r\n\tVALUES\r\n    ('Göte Guld', 'Ett riktigt gött Göte öl med smak av hembygd.', 45.99, 6.5, 0, 0, 1, 0, 'assets/img/GöteGuld.jpg'),\r\n    ('Västra Stoutet', 'Ett riktigt mörkt och tufft stout från väst.', 55.50, 7.0, 0, 0, 1, 0, 'assets/img/VästraStoutet.jpg'),\r\n    ('Göta Lättöl', 'En frisk och lätt öl direkt från götarnas land.', 32.75, 2.5, 0, 1, 1, 0, 'assets/img/GötaLättöl.jpg'),\r\n    ('Härlig Pale Ale', 'En pale ale så härlig att den går rakt in i hjärtat.', 42.25, 5.2, 0, 1, 1, 0, 'assets/img/HärligPaleAle.jpg'),\r\n    ('Västra Vetet', 'Ett ljust och fruktigt vetöl som bara götar förstår.', 38.99, 4.8, 0, 1, 1, 0, 'assets/img/VästraVetet.jpg'),\r\n    ('Röd Göte Ale', 'En röd ale med smak av äkta götekaraktär.', 47.75, 6.0, 0, 1, 1, 0, 'assets/img/RödGöteAle.jpg'),\r\n    ('Belgisk Göte', 'En stark och komplex belgisk göte med smak av frihet och kryddor.', 65.00, 8.5, 0, 0, 1, 0, 'assets/img/BelgiskGöte.jpg'),\r\n    ('Klassisk Göte Pils', 'En klassisk och frisk göte pilsner för äkta götekänsla.', 36.50, 4.5, 0, 1, 1, 0, 'assets/img/KlassiskGötePils.jpg'),\r\n    ('Surt Göte', 'Ett surt göte öl som får munnen att vattnas.', 40.25, 4.2, 0, 1, 1, 0, 'assets/img/SurtGöte.jpg'),\r\n    ('Göte Porter Excellence', 'En mörk och utsökt göte porter med smak av götakärlek.', 52.99, 6.8, 0, 0, 0, 0, 'assets/img/GötePorterExcellence.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
