using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProductCategories(CategoryId, ProductId)\r\n\tVALUES \r\n\t(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),\r\n\t(2,25),(2,28),(2,29),(2,21),(2,22),\r\n\t(3,23),(3,24),(3,26),(3,27),(3,30),\r\n\r\n\t(5, 11),(5,12),(5,13),(5,14),(5,16),(5,17),(5,18),(5,19),(5,20),\r\n\t(6, 33),(6, 34),(6, 35),(6, 36),(6, 37),(6, 38),(6, 39),(6, 40),(6, 41),(6, 42),\r\n\t(7, 43),(7, 44),(7, 45),(7, 46),(7, 47),\r\n\t(8,31),\r\n\t(9,32);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
