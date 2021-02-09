using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Padarogga.Server.Migrations
{
    public partial class AddRoutePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Authors",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "RoutePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    RouteId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutePayments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutePayments_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutePayments_CustomerId",
                table: "RoutePayments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePayments_RouteId",
                table: "RoutePayments",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutePayments");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Authors");
        }
    }
}
