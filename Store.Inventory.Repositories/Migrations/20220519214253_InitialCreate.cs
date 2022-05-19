using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Inventory.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_InventoryStatus_InventoryStatusId",
                        column: x => x.InventoryStatusId,
                        principalTable: "InventoryStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6171), true, "Category1", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6173) },
                    { 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6176), true, "Category2", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6177) }
                });

            migrationBuilder.InsertData(
                table: "InventoryStatus",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6015), true, "Sold", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6028) },
                    { 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6116), true, "Damaged", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6117) },
                    { 3, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6118), true, "InStock", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6119) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BarCode", "CreatedBy", "CreatedDate", "Description", "InventoryStatusId", "IsActive", "Name", "StatusId", "UpdatedBy", "UpdatedDate", "Weight" },
                values: new object[,]
                {
                    { 1, "BarCode1", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6210), "Test Product 1", null, true, "Product1", 3, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6211), 20.0 },
                    { 2, "BarCode2", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6216), "Test Product 2", null, true, "Product2", 3, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6216), 30.0 },
                    { 3, "BarCode3", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6219), "Test Product 3", null, true, "Product3", 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6220), 40.0 },
                    { 4, "BarCode4", "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6223), "Test Product 4", null, true, "Product4", 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 683, DateTimeKind.Local).AddTicks(6224), 50.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "IsActive", "ProductId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(62), true, 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(69) },
                    { 2, 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(74), true, 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(75) },
                    { 3, 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(77), true, 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(78) },
                    { 4, 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(79), true, 3, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(79) },
                    { 5, 1, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(81), true, 4, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(81) },
                    { 6, 2, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(85), true, 4, "System", new DateTime(2022, 5, 20, 1, 42, 52, 684, DateTimeKind.Local).AddTicks(85) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_InventoryStatusId",
                table: "Product",
                column: "InventoryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "InventoryStatus");
        }
    }
}
