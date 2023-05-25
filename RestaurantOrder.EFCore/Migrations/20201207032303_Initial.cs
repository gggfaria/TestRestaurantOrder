using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantOrder.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 12, 7, 3, 23, 3, 16, DateTimeKind.Utc).AddTicks(9926)),
                    Name = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 12, 7, 3, 23, 2, 995, DateTimeKind.Utc).AddTicks(6192)),
                    Code = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<int>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 12, 7, 3, 23, 3, 29, DateTimeKind.Utc).AddTicks(922)),
                    ProductName = table.Column<string>(maxLength: 300, nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_IsActive",
                table: "Areas",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_IsActive",
                table: "ItemOrders",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AreaId",
                table: "Orders",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsActive",
                table: "Orders",
                column: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
