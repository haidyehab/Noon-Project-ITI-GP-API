using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliExpress.Context.Migrations
{
    /// <inheritdoc />
    public partial class pkmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imaage",
                table: "ProductBrands",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ProductBrands",
                newName: "Imaage");
        }
    }
}
