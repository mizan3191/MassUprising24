using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MassUprising24.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class warriorTableColumnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueId",
                table: "Warriors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Warriors");
        }
    }
}
