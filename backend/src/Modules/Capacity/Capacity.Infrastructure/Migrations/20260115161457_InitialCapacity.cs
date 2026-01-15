using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capacity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "capacity");

            migrationBuilder.CreateTable(
                name: "Beds",
                schema: "capacity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beds",
                schema: "capacity");
        }
    }
}
