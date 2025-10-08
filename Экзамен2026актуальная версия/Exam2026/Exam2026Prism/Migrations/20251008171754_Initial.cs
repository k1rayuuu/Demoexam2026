using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam2026Prism.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PickUpPoints");

            migrationBuilder.DropTable(
                name: "Tovars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
