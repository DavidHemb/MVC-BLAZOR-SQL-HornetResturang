using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Huvudrätter', 0, 0, 12)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Desserter', 0, 0, 12)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Godsaker', 0, 0, 12)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Snacks', 0, 0, 12)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Drinkar', 1, 0, 25)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Öl', 1, 0, 25)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Alkoholfritt', 1, 0, 12)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Böcker', 0, 0, 6)\r\nINSERT INTO Categories (Name, Liquid, IsDeleted, VatRate) \r\nValues('Kläder', 0, 0, 25)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
