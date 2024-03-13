using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 13, 57, 5, 5, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.CreateIndex(
                name: "IX_Problems_CategoryId",
                table: "Problems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Category_CategoryId",
                table: "Problems",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Category_CategoryId",
                table: "Problems");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Problems_CategoryId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Problems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 12, 1, 11, 39, 272, DateTimeKind.Local).AddTicks(7298));
        }
    }
}
