using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "char(64)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.UniqueConstraint("AK_Users_Login", x => x.Login);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "IsEnabled", "Login", "Password", "UniversityID" },
                values: new object[] { 1, new DateTime(2024, 2, 28, 23, 11, 32, 853, DateTimeKind.Local).AddTicks(6196), true, "user", "ee11cbb19052e40b07aac0ca060c23ee", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
