using Microsoft.EntityFrameworkCore.Migrations;

namespace Padarogga.Server.Migrations
{
    public partial class AddRouteDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Waypoints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Waypoints",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Routes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Waypoints");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Waypoints");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Routes");
        }
    }
}
