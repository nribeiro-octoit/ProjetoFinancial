using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialAPI.Migrations
{
    public partial class CreateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Expense",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_IdCategory",
                table: "Income",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_IdCategory",
                table: "Expense",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_IdCategory",
                table: "Expense",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Category_IdCategory",
                table: "Income",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_IdCategory",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Category_IdCategory",
                table: "Income");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Income_IdCategory",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Expense_IdCategory",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Expense");
        }
    }
}
