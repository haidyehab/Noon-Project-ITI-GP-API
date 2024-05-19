using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliExpress.Context.Migrations
{
    /// <inheritdoc />
    public partial class saddasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath_AR",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath_AR",
                table: "Brands");
        }
    }
}
