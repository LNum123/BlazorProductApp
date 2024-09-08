using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorProduct.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTimeCaptured = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateTimeCaptured", "Model", "Name", "PartNumber", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3955f33e-af31-4547-877e-615484de9cd1"), new DateTime(2024, 8, 14, 7, 30, 21, 822, DateTimeKind.Utc).AddTicks(638), "MK450", "Mechanical Keyboard", "MK450-456", 89.99m, 30 },
                    { new Guid("87934a87-b6c2-4a41-845a-8d1b653acd04"), new DateTime(2024, 8, 14, 7, 30, 21, 822, DateTimeKind.Utc).AddTicks(826), "XH1TB", "External Hard Drive", "XH1TB-102", 59.99m, 75 },
                    { new Guid("c0c58c14-fe69-4b60-b739-47c3fd7580f7"), new DateTime(2024, 8, 14, 7, 30, 21, 822, DateTimeKind.Utc).AddTicks(702), "GH200", "Gaming Headset", "GH200-789", 59.99m, 25 },
                    { new Guid("d9ee4d98-d4ac-410f-ad88-22cfae7227d1"), new DateTime(2024, 8, 14, 7, 30, 21, 822, DateTimeKind.Utc).AddTicks(766), "UHD27", "4K Monitor", "UHD27-101", 299.99m, 10 },
                    { new Guid("e15bd8dc-5f05-422d-8fdd-b7bd7866265b"), new DateTime(2024, 8, 14, 7, 30, 21, 822, DateTimeKind.Utc).AddTicks(497), "MX1000", "Wireless Mouse", "WMX1000-123", 29.99m, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
