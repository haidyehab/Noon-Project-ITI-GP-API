using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AliExpress.Context.Migrations
{
    /// <inheritdoc />
    public partial class ratedegreee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreeRate",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeRate",
                table: "Rates");
        }
    }
}
